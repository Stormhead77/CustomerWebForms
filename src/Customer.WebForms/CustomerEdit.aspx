<%@ Page Title="Customer Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="Customer.WebForms.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="addEdit" Text="New Customer" runat="server"></asp:Label>

        <div class="form-group">
            <asp:Label Text="First Name" runat="server"></asp:Label>
            <asp:TextBox ID="firstName" CssClass="form-control" runat="server"></asp:TextBox>
        </div>

        <div class="form-group">
            <asp:Label Text="Last Name" runat="server"></asp:Label>
            <asp:TextBox ID="lastName" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="lastName" ErrorMessage="Last Name required"/>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="lastName" ValidationExpression=".{1,50}" ErrorMessage="Last Name too long"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Phone Number" runat="server"></asp:Label>
            <asp:TextBox ID="phoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="phoneNumber" ValidationExpression="\+\d{5,15}" ErrorMessage="Invalid phone number format"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Email" runat="server"></asp:Label>
            <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="email" ValidationExpression="[[:alnum:]]+@[[:alnum:]]+\.[[:alnum:]]+" ErrorMessage="Invalid email format"/>
        </div>

        <asp:Button CssClass="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"></asp:Button>

        <asp:Button ID="delete" CssClass="btn btn-danger" Text="Delete" Visible="false" runat="server" OnClick="OnClickDelete"></asp:Button>
    </div>

    <div>
        <asp:Label Text="Addresses" runat="server"></asp:Label>

        <table class="table">
            <% foreach (var address in Addresses)
                { %>
            <tr>
                <td>
                    <% =address.AddressLine %>
                </td>
                <td>
                    <% =address.AddressLine2 %>
                </td>
                <td>
                    <% =address.Type %>
                </td>
                <td>
                    <% =address.City %>
                </td>
                <td>
                    <% =address.PostalCode %>
                </td>
                <td>
                    <% =address.State %>
                </td>
                <td>
                    <% =address.Country %>
                </td>
                <td class="btn btn-link">
                    <a href="AddressEdit.aspx?addressId=<% =address.Id %>">Edit</a>
                </td>
            </tr>
               <% } %>
        </table>

        <asp:Button ID="addAddress" CssClass="btn btn-primary" Text="Add" Visible="false" runat="server" OnClick="OnClickAddAddress"></asp:Button>
    </div>

</asp:Content>
