<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ManagerPanel.aspx.cs" Inherits="Auth_AuthCLA.ManagerPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Manager Panel
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <div class="container mt-3">
        <form id="form1" runat="server">
            <div class="card border-1 shadow-lg p-3">
                <h2 class="display-6 fw-bolder text-center text-light bg-dark p-2">Manager Panel</h2>
                <div class="form-group my-2">
                    <asp:Label ID="LabUsername" runat="server" Text="Username: " CssClass="fw-bolder"></asp:Label>
                    <asp:Label ID="LabUsernameVal" runat="server"></asp:Label>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabUserID" runat="server" Text="User ID: " CssClass="fw-bolder"></asp:Label>
                    <asp:Label ID="LabUserIDVal" runat="server"></asp:Label>
                </div>

                <div class="d-flex align-items-center justify-content-center gap-3">
                    <asp:Button ID="BtnLogout" runat="server" Text="Logout" CssClass="btn btn-danger w-25" OnClick="BtnLogout_Click"/>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
