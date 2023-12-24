<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3007.aspx.cs" Inherits="personal_page_info.profileSite._3007" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>My Profile</title>
    <style>
        /* Thiết lập CSS cho giao diện */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
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

        .profile-avatar img {
            width: 150px; /* Tăng kích thước hình ảnh avatar */
            height: 150px; /* Tăng kích thước hình ảnh avatar */
            border-radius: 50%; /* Làm tròn góc cho hình ảnh */
            margin-bottom: 20px;
        }

        .profile-header h1 {
            margin-bottom: 10px;
            color: #333;
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
</head>
<body>
    <form id="form1" runat="server">
        <div class="profile-container">

            <div class="profile-header">
            </div>
            <div class="profile-avatar"><asp:Image ID="avatar" runat="server" /></div>
                <asp:Label ID="txtname" runat="server" Text="Your Name" Font-Size="40px"></asp:Label>
                <br />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:Label ID="phonenumber" runat="server" Text="phone number"></asp:Label> 
                <!-- <asp:Label ID="txtbio" runat="server" Text="Your Bio or Description" Font-Size="small"></asp:Label> -->
            
            <ul class="profile-links">
                <asp:HyperLink ID="websitelink" runat="server">Website</asp:HyperLink>
               <!-- <asp:Label ID="phonenumber" runat="server" Text="phone number"></asp:Label> -->
                <asp:HyperLink ID="facebooklink" runat="server">Facebook</asp:HyperLink>
                <asp:HyperLink ID="linelink" runat="server">LINE</asp:HyperLink>
                <asp:HyperLink ID="youtubelink" runat="server">Youtube</asp:HyperLink>
                <!-- Thêm các link khác tương tự -->
            </ul>
        </div>
    </form>
</body>
</html>