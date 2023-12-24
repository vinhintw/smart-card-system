<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="personal_page_info.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validateForm() {
            var userName = document.getElementById('<%= txtUserName.ClientID %>').value;
            var password = document.getElementById('<%= txtPassword.ClientID %>').value;
            var confirmPassword = document.getElementById('<%= TextBox1.ClientID %>').value;
            var email = document.getElementById('<%= txtEmail.ClientID %>').value;
            var regcode = document.getElementById('<%= txtregcode.ClientID %>').value;

            // Kiểm tra mật khẩu có ít nhất 8 ký tự, chứa chữ cái và số
            var passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
            if (!passwordRegex.test(password)) {
                alert("Password must contain at least 8 characters, including letter and number.");
                return false;
            }

            // Kiểm tra email có định dạng đúng
            var emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(email)) {
                alert("Please enter a valid email address.");
                return false;
            }

            // Kiểm tra xác nhận mật khẩu
            if (password !== confirmPassword) {
                alert("Passwords do not match.");
                return false;
            }
            var regcode = document.getElementById('<%= txtregcode.ClientID %>').value;

            if (isNaN(regcode)) {
                alert("Register Code must be a number.");
                return false;
            }
            return true; // Nếu các điều kiện đều đúng, cho phép submit form
        }

        // Gán hàm validateForm cho sự kiện onclick của nút Register
        document.getElementById('<%= btnRegister.ClientID %>').onclick = function() {
            return validateForm();
        };
    </script>
    <h2>Register</h2>

    <div class="form-group">
        <asp:Label ID="lblID" runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="Confirm Password: "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Register Code"></asp:Label>
        <asp:TextBox ID="txtregcode" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="regnotify" runat="server" Text=""></asp:Label>
    </div>

    <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" CssClass="btn btn-primary" OnClientClick="return validateForm();"/>

</asp:Content>
