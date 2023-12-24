<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="personal_page_info.Admin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="false" OnRowCommand="GridViewUsers_RowCommand">
        <Columns>
            <asp:BoundField DataField="code" HeaderText="Register code" />
            <asp:BoundField DataField="Id" HeaderText="User ID" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                   <asp:DropDownList ID="Paid_Check" runat="server" OnSelectedIndexChanged="updatePaidStatus" AutoPostBack="true">
                        <asp:ListItem Text="Not yet"></asp:ListItem>
                        <asp:ListItem Text="Paided"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="DeleteRow" CommandArgument='<%# Container.DataItemIndex %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button runat="server" Text="Add new User" OnClick="AddNewUser_Click" />
</asp:Content>
