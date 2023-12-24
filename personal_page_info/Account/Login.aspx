<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="personal_page_info.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4 col-md-offset-4">
            <h2>Login</h2>
            <p>Enter your credentials to access your account.</p>
            <asp:Label runat="server" ID="lblError" CssClass="text-danger"></asp:Label>

            <asp:ValidationSummary runat="server" ID="valSummary" ValidationGroup="LoginUser" CssClass="text-danger" />

            <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" placeholder="Username" ValidationGroup="LoginUser"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername" CssClass="text-danger" ErrorMessage="Username is required." ValidationGroup="LoginUser"></asp:RequiredFieldValidator>

            <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Password" ValidationGroup="LoginUser"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" CssClass="text-danger" ErrorMessage="Password is required." ValidationGroup="LoginUser"></asp:RequiredFieldValidator>

            <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" ValidationGroup="LoginUser" />
            <div class="text-center">
                <p><a href="Register.aspx">Don't have an account? Register here.</a></p>
            </div>
        </div>
    </div>
</asp:Content>
