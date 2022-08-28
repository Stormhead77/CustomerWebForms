<%@ Page Title="Customers" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="Customer.WebForms.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <a class="btn btn-primary" href="CustomerEdit.aspx">Add</a>

    <table class="table">
        <% foreach (var customer in Customers)
            { %>
        <tr>
            <td>
                <% =customer.FirstName %>
            </td>
            <td>
                <% =customer.LastName %>
            </td>
            <td class="btn btn-link">
                <a href="CustomerEdit.aspx?customerId=<% =customer.Id %>">Edit</a>
            </td>
        </tr>
           <% } %>
    </table>

    <asp:Button ID="btnPrev" CssClass="btn btn-secondary" Text="Prev" runat="server" OnClick="OnClickPrev"></asp:Button>
    
    <asp:Button ID="btnNext" CssClass="btn btn-secondary" Text="Next" runat="server" OnClick="OnClickNext"></asp:Button>

</asp:Content>
