<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="Auth_AuthCOA.AdminPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Admin Panel
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <div class="container mt-3">
        <form id="form1" runat="server">
            <div class="card border-1 shadow-lg p-3">
                <h2 class="display-6 fw-bolder text-center text-light bg-dark p-2">Admin Panel</h2>
                <div class="form-group my-2">
                    <asp:Label ID="LabSelectUser" runat="server" Text="Select User"></asp:Label>
                    <asp:DropDownList ID="DdlUsers" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabSelectRole" runat="server" Text="Select Role"></asp:Label>
                    <asp:DropDownList ID="DdlRole" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Select Role"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Manager"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Employee"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="d-flex align-items-center justify-content-center gap-3">
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-success w-25" OnClick="BtnSearch_Click"/>
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-primary w-25" OnClick="BtnUpdate_Click"/>
                    <asp:Button ID="BtnLogout" runat="server" Text="Logout" CssClass="btn btn-danger w-25" OnClick="BtnLogout_Click"/>
                </div>

                <div class="mt-3">
                    <h2 class="display-6 fw-bolder text-center text-light bg-dark p-2">Users List</h2>
                    <asp:DataGrid ID="GridUsers" runat="server" CssClass="table table-bordered table-striped mt-2"></asp:DataGrid>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
