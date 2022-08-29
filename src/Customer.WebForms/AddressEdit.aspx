<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddressEdit.aspx.cs" Inherits="Customer.WebForms.AddressEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <asp:Label ID="addEdit" Text="New Address" runat="server"></asp:Label>

        <div class="form-group">
            <asp:Label Text="Address line" runat="server"></asp:Label>
            <asp:TextBox ID="addressLine" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="addressLine" ErrorMessage="Address line required"/>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="addressLine" ValidationExpression=".{1,100}" ErrorMessage="Address line too long"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Address line2" runat="server"></asp:Label>
            <asp:TextBox ID="addressLine2" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="addressLine" ValidationExpression=".{0,100}" ErrorMessage="Address line2 too long"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Type" runat="server"></asp:Label>
            <asp:TextBox ID="type" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="type" ErrorMessage="Type required"/>
        </div>

        <div class="form-group">
            <asp:Label Text="City" runat="server"></asp:Label>
            <asp:TextBox ID="city" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="city" ErrorMessage="City required"/>
            <asp:RegularExpressionValidator runat="server" ControlToValidate ="city" ValidationExpression=".{1,50}" ErrorMessage="City too long"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Postal code" runat="server"></asp:Label>
            <asp:TextBox ID="postalCode" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="postalCode" ErrorMessage="Postal code required"/>
        </div>

        <div class="form-group">
            <asp:Label Text="State" runat="server"></asp:Label>
            <asp:TextBox ID="state" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="state" ErrorMessage="State required"/>
        </div>

        <div class="form-group">
            <asp:Label Text="Country" runat="server"></asp:Label>
            <asp:TextBox ID="country" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate ="country" ErrorMessage="Country required"/>
        </div>

        <asp:Button CssClass="btn btn-primary" Text="Save" runat="server" OnClick="OnClickSave"></asp:Button>

        <asp:Button ID="delete" CssClass="btn btn-danger" Text="Delete" Visible="false" runat="server" OnClick="OnClickDelete"></asp:Button>
    </div>

</asp:Content>
