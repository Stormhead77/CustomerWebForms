using CustomerDatalayer.Repositories;
using System;

namespace Customer.WebForms
{
    public partial class AddressEdit : System.Web.UI.Page
    {
        readonly AddressRepository AddressRepository = new AddressRepository();

        CustomerDatalayer.Entities.Address Address;

        protected void Page_Load(object sender, EventArgs e)
        {
            var addressIdStr = Request.QueryString["addressId"];
            if (addressIdStr == null)
            {
                Response.Redirect("CustomerList.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    Address = AddressRepository.Read(int.Parse(addressIdStr));

                    addressLine.Text = Address.AddressLine;
                    addressLine2.Text = Address.AddressLine2;
                    type.Text = Address.Type;
                    city.Text = Address.City;
                    postalCode.Text = Address.PostalCode;
                    state.Text = Address.State;
                    country.Text = Address.Country;
                }
            }
        }

        protected void OnClickSave(object sender, EventArgs e)
        {
            var addressIdStr = Request.QueryString["addressId"];
            if (addressIdStr == null)
            {
                Address = AddressRepository.Read(int.Parse(addressIdStr));
                Address.AddressLine = addressLine.Text;
                Address.AddressLine2 = addressLine2.Text;
                Address.Type = type.Text;
                Address.City = city.Text;
                Address.PostalCode = postalCode.Text;
                Address.State = state.Text;
                Address.Country = country.Text;

                AddressRepository.Update(Address);
            }

            var customerIdStr = Request.QueryString["customerId"];
            if (customerIdStr != null)
            {
                Address = new CustomerDatalayer.Entities.Address
                {
                    CustomerId = int.Parse(customerIdStr),
                    AddressLine = addressLine.Text,
                    AddressLine2 = addressLine2.Text,
                    Type = type.Text,
                    City = city.Text,
                    PostalCode = postalCode.Text,
                    State = state.Text,
                    Country = country.Text,
                };
                
                AddressRepository.Create(Address);
            }

            Response.Redirect("CustomerList.aspx?customerId=" + Address.CustomerId);
        }

        protected void OnClickDelete(object sender, EventArgs e)
        {
            var addressIdStr = Request.QueryString["addressId"];
            Address = AddressRepository.Read(int.Parse(addressIdStr));
            AddressRepository.Delete(Address.Id);

            Response.Redirect("CustomerList.aspx?customerId=" + Address.CustomerId);
        }
    }
}