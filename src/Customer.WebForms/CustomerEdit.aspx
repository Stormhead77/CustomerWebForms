<%@ Page Title="Customer Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerEdit.aspx.cs" Inherits="Customer.WebForms.CustomerEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Label ID="addEdit" Text="New Customer" runat="server"></asp:Label>

    <div class="form-group">
        <asp:Label Text="First Name" runat="server"></asp:Label>
        <asp:TextBox ID="firstName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label Text="Last Name" runat="server"></asp:Label>
        <asp:TextBox ID="lastName" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label Text="Phone Number" runat="server"></asp:Label>
        <asp:TextBox ID="phoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label Text="Email" runat="server"></asp:Label>
        <asp:TextBox ID="email" CssClass="form-control" runat="server"></asp:TextBox>
    </div>

    <asp:Button CssClass="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"></asp:Button>

    <asp:Button ID="delete" CssClass="btn btn-danger" Text="Delete" Visible="false" runat="server" OnClick="OnClickDelete"></asp:Button>

</asp:Content>
