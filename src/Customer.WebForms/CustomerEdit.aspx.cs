using System;

namespace Customer.WebForms
{
    public partial class CustomerEdit : System.Web.UI.Page
    {
        CustomerDatalayer.Repositories.CustomerRepository CustomerRepository = new CustomerDatalayer.Repositories.CustomerRepository();
        CustomerDatalayer.Entities.Customer Customer;

        protected void Page_Load(object sender, EventArgs e)
        {
            var customerIdStr = Request.QueryString["customerId"];
            if (customerIdStr != null)
            {
                if (!IsPostBack)
                {
                    addEdit.Text = "Customer Edit";
                    delete.Visible = true;

                    Customer = CustomerRepository.Read(int.Parse(customerIdStr));

                    firstName.Text = Customer.FirstName;
                    lastName.Text = Customer.LastName;
                    phoneNumber.Text = Customer.PhoneNumber;
                    email.Text = Customer.Email;
                }
            }
        }

        protected void OnClickSave(object sender, EventArgs e)
        {
            var customer = new CustomerDatalayer.Entities.Customer()
            {
                FirstName = firstName.Text,
                LastName = lastName.Text,
                PhoneNumber = phoneNumber.Text,
                Email = email.Text,
                TotalPurchasesAmount = Customer?.TotalPurchasesAmount,
            };

            var customerIdStr = Request.QueryString["customerId"];
            if (customerIdStr != null)
            {
                customer.Id = int.Parse(customerIdStr);

                CustomerRepository.Update(customer);
            }
            else
            {
                CustomerRepository.Create(customer);
            }

            Response.Redirect("CustomerList.aspx");
        }

        protected void OnClickDelete(object sender, EventArgs e)
        {
            var customerRepository = new CustomerDatalayer.Repositories.CustomerRepository();
            var customerIdStr = Request.QueryString["customerId"];
            customerRepository.Delete(int.Parse(customerIdStr));

            Response.Redirect("CustomerList.aspx");
        }
    }
}