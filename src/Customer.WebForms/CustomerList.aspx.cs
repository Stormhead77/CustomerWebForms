using System;
using System.Collections.Generic;

namespace Customer.WebForms
{
    public partial class CustomerList : System.Web.UI.Page
    {
        public List<CustomerDatalayer.Entities.Customer> Customers { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var _customerRepository = new CustomerDatalayer.Repositories.CustomerRepository();
            Customers = _customerRepository.GetAll();
        }
    }
}