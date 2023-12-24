<%@ Page Title="" Language="C#" MasterPageFile="~/HOme.Master" AutoEventWireup="true" CodeBehind="Manager.aspx.cs" Inherits="personal_page_info.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .avatar-image {
            width: 100px; /* Điều chỉnh kích thước chiều rộng */
            height: auto; /* Tự động điều chỉnh chiều cao để giữ tỷ lệ khung hình */
        }
        .container {
            display: flex;
            justify-content: space-between;
        }
        .profile-container {
            max-width: 600px;
            margin: 20px auto;
            background-color: #fff;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            padding: 20px;
            border-radius: 10px;
            text-align: center;
        }
        .edit-section {
            width: 45%; /* Điều chỉnh kích thước phần chỉnh sửa */
        }

        .preview-section {
            width: 45%; /* Điều chỉnh kích thước phần hiển thị */
        }

        /* CSS cho phần hiển thị thông tin */
        .preview-section {
            margin: 20px;
            border: 1px solid #ccc;
            padding: 10px;
            border-radius: 5px;
            background-color: #f9f9f9;
        }

        .preview-section img {
            width: 150px;
            height: 150px;
            border-radius: 50%;
            margin-bottom: 20px;

        }

        .preview-section ul {
            list-style: none;
            padding: 0;
        }

        /* CSS cho phần chỉnh sửa thông tin */
        .edit-section {
            margin: 20px;
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            background-color: #fff;
        }

        .edit-section .form-group {
            margin-bottom: 10px;
        }
        .profile-links {
            list-style: none;
            padding: 0;
            margin: 20px 0;
            display: flex;
            flex-direction: column;
            gap: 10px;
        }

        .profile-links a {
            padding: 10px;
            text-decoration: none;
            color: #333;
            background-color: #f9f9f9;
            border-radius: 5px;
            display: block;
            text-align: center;
            transition: background-color 0.3s ease;
        }

        .profile-links a:hover {
            background-color: #e3e3e3;
        }
    </style>
    <script type="text/javascript">
        function validateForm() {
            var phoneNumber = document.getElementById('<%= txtPhone.ClientID %>').value;
            var isNumeric = /^\d{0,11}$/.test(phoneNumber);


            if (!isNumeric) {
                alert('Please enter a valid phone number.');
                return false; // Không cho submit form nếu giá trị không phải là số
            }

            return true;
        }

        // Gán hàm validateForm cho sự kiện onclick của nút Register
        document.getElementById('<%= btnConfirm.ClientID %>').onclick = function() {
            return validateForm();
        };
    </script>

    <div class="edit-section">
        <!-- Đặt các thành phần chỉnh sửa thông tin vào đây -->
        <div class="form-group">
            <asp:Label ID="Label5" runat="server" Text="Avatar: "></asp:Label>
            <asp:FileUpload ID="imgfile" runat="server" />


        </div>
    <div class="form-group">

        <asp:Label ID="name" runat="server" Text="Name: "></asp:Label>
        <asp:TextBox ID="txtName" runat="server" placeholder="Name" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="label" runat="server" Text="Phone: "></asp:Label>
        <asp:TextBox ID="txtPhone" runat="server" placeholder="Phone" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Website: "></asp:Label>
        <asp:TextBox ID="txtWebsite" runat="server" placeholder="Website" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="Facebook: "></asp:Label>
        <asp:TextBox ID="txtFacebook" runat="server" placeholder="Facebook" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="LINE: "></asp:Label>
        <asp:TextBox ID="txtLine" runat="server" placeholder="LINE" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Youtube: "></asp:Label>
        <asp:TextBox ID="txtYoutube" runat="server" placeholder="YouTube" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="notify" runat="server" Text=""></asp:Label>
    </div>

    <div class="btn-toolbar">
        <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" CssClass="btn btn-primary mr-2" />
        <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" CssClass="btn btn-success" OnClientClick="return validateForm();"/>
    </div>
    </div>
    <div class="preview-section">
        <div class="profile-container">
            <div>
            <asp:Image ID="preavatar" runat="server" CssClass="avatar-image" />
        </div>
        <asp:Label ID="prename" runat="server" Text="Your Name" Font-Size="40px"></asp:Label>
        <br />
        <asp:Label ID="prephone" runat="server" Text="Phone"></asp:Label>
        <ul class="profile-links">
            <asp:HyperLink ID="prewebsitelink" runat="server">Website</asp:HyperLink>
            <asp:HyperLink ID="prefacebooklink" runat="server">Facebook</asp:HyperLink>
            <asp:HyperLink ID="prelinelink" runat="server">LINE</asp:HyperLink>
            <asp:HyperLink ID="preyoutubelink" runat="server">Youtube</asp:HyperLink>
            <!-- Thêm các link khác tương tự -->
        </ul>
    </div>
        </div>
</asp:Content>
