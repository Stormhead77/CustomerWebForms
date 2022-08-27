using CustomerDatalayer.Entities;
using CustomerDatalayer.Interfaces;
using CustomerDatalayer.Repositories;
using FluentAssertions;

namespace CustomerDatalayer.Tests.Entities
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCustomerRepository()
        {
            CustomerRepository repository = new CustomerRepository();
            repository.Should().NotBeNull();
        }

        [Fact]
        public void ShouldImplementIRepository()
        {
            CustomerRepository repository = new CustomerRepository();
            repository.GetType().GetInterfaces().Should().Contain((typeof(IRepository<Customer>)));

            //IRepository<Customer> repository = new CustomerRepository();
        }

        [Fact]
        public void ShouldBeAbleToCreateCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            CustomerRepository repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            createdCustomer.Should().NotBeNull();
            createdCustomer.FirstName.Should().Be(customer.FirstName);
            createdCustomer.LastName.Should().Be(customer.LastName);
            createdCustomer.PhoneNumber.Should().Be(customer.PhoneNumber);
            createdCustomer.Email.Should().Be(customer.Email);
            createdCustomer.TotalPurchasesAmount.Should().Be(customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldBeAbleToReadCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            CustomerRepository repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            var createdCustomer = repository.Create(customer);
            var readCustomer = repository.Read(createdCustomer.Id);

            readCustomer.Should().NotBeNull();
            readCustomer.FirstName.Should().Be(customer.FirstName);
            readCustomer.LastName.Should().Be(customer.LastName);
            readCustomer.PhoneNumber.Should().Be(customer.PhoneNumber);
            readCustomer.Email.Should().Be(customer.Email);
            readCustomer.TotalPurchasesAmount.Should().Be(customer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldNotBeAbleToReadCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            CustomerRepository repository = new CustomerRepository();
            var readCustomer = repository.Read(0);

            readCustomer.Should().BeNull();
        }

        [Fact]
        public void ShouldBeAbleToUpdateCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            CustomerRepository repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            createdCustomer.FirstName = "Garry";
            repository.Update(createdCustomer);

            var updatedCustomer = repository.Read(createdCustomer.Id);

            updatedCustomer.Should().NotBeNull();
            updatedCustomer.FirstName.Should().Be("Garry");
            updatedCustomer.LastName.Should().Be(createdCustomer.LastName);
            updatedCustomer.PhoneNumber.Should().Be(createdCustomer.PhoneNumber);
            updatedCustomer.Email.Should().Be(createdCustomer.Email);
            updatedCustomer.TotalPurchasesAmount.Should().Be(createdCustomer.TotalPurchasesAmount);
        }

        [Fact]
        public void ShouldNotBeAbleToUpdateCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            CustomerRepository repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            createdCustomer.Id = 0;
            createdCustomer.FirstName = "Garry";
            int updatedCustomers = repository.Update(createdCustomer);

            updatedCustomers.Should().Be(0);
        }

        [Fact]
        public void ShouldBeAbleToDeleteCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            CustomerRepository repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            var createdCustomer = repository.Create(customer);

            int deletedRows = repository.Delete(createdCustomer.Id);

            deletedRows.Should().Be(1);
        }

        [Fact]
        public void ShouldNotBeAbleToDeleteCustomer()
        {
            CustomersRepositoryFixture.DeleteAll();

            CustomerRepository repository = new CustomerRepository();

            var customer = CustomersRepositoryFixture.GetCustomer();

            repository.Create(customer);

            int deletedRows = repository.Delete(0);

            deletedRows.Should().Be(0);
        }
    }
}
