using System;
using System.Collections.Generic;

namespace Customer.WebForms
{
    public partial class CustomerList : System.Web.UI.Page
    {
        private const int PageSize = 2;

        private int pageNum;
        public List<CustomerDatalayer.Entities.Customer> Customers { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var pageStr = Request.QueryString["page"];
            pageNum = string.IsNullOrEmpty(pageStr) ? 1 : int.Parse(pageStr);

            var _customerRepository = new CustomerDatalayer.Repositories.CustomerRepository();

            btnPrev.Enabled = pageNum > 1;
            btnNext.Enabled = pageNum < (_customerRepository.GetCount() + PageSize - 1) / PageSize;

            Customers = _customerRepository.GetPage(PageSize, pageNum, "FirstName");
        }

        protected void OnClickPrev(object sender, EventArgs e)
        {
            Response.Redirect($"CustomerList.aspx?page={pageNum - 1}");
        }

        protected void OnClickNext(object sender, EventArgs e)
        {
            Response.Redirect($"CustomerList.aspx?page={pageNum + 1}");
        }
    }
}