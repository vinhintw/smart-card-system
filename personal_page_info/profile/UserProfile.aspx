<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="personal_page_info.UserProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Image ID="imgAvatar" runat="server" CssClass="avatar" />

        <div>
            <asp:Label ID="lblUsername" runat="server" Text="Username: " CssClass="info-label"></asp:Label>
            <br />
            <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: " CssClass="info-label"></asp:Label>
            <br />
            <!-- Thêm các điều khiển khác tương tự cho các thông tin khác -->

            <asp:HyperLink ID="website" runat="server" Text="WebSite" NavigateUrl="" CssClass="social-link"></asp:HyperLink>
            <br />
            <asp:HyperLink ID="facebook" runat="server" Text="Facebook" NavigateUrl="" CssClass="social-link"></asp:HyperLink>
            <br />
            <asp:HyperLink ID="line" runat="server" Text="LINE" NavigateUrl="" CssClass="social-link"></asp:HyperLink>
            <br />
            <asp:HyperLink ID="youtube" runat="server" Text="Youtube" NavigateUrl="" CssClass="social-link"></asp:HyperLink>
            <!-- Thêm các liên kết mạng xã hội khác tương tự -->
        </div>
    </div>

</asp:Content>
