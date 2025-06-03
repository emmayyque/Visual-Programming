<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="A8Authentication_AuthCOA.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Admin Panel
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <div class="container mt-5">
        <form id="form1" runat="server" class="mx-auto w-50">
            <div class="my-2 form-group">
                <asp:Label ID="LabUserSelect" runat="server" Text="Select User"></asp:Label>
                <div class="row gap-2 mx-0">
                    <asp:DropDownList ID="DdlUsers" runat="server" CssClass="form-control w-50"></asp:DropDownList>
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary w-25" OnClick="BtnSearch_Click" />
                </div>
            </div>
            <div class="my-2 form-group">
                <asp:Label ID="LabRole" runat="server" Text="Role"></asp:Label>
                <asp:DropDownList ID="DdlRole" runat="server" CssClass="form-control w-50">
                    <asp:ListItem runat="server" Text="Select Role" Value=""></asp:ListItem>
                    <asp:ListItem runat="server" Text="Manager" Value="2"></asp:ListItem>
                    <asp:ListItem runat="server" Text="Employee" Value="3"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mt-4 form-group text-center row gap-2 mx-auto w-100">
                <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-success w-25" OnClick="BtnUpdate_Click" />
                <asp:Button ID="BtnLogout" runat="server" Text="Logout" CssClass="btn btn-danger w-25" OnClick="BtnLogout_Click" />
            </div>

            <div class="my-4">
                <asp:Label ID="LabResult" runat="server"></asp:Label>
            </div>

            <div class="mt-3">
                <asp:DataGrid ID="GridUsers" runat="server" CssClass="table table-bordered table-striped"></asp:DataGrid>
            </div>
        </form>
    </div>
</asp:Content>