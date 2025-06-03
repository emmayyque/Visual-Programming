<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="ManagerPanel.aspx.cs" Inherits="A8Authentication_AuthCOA.ManagerPanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Manager Panel
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <div class="container mt-5">
        <h2 class="display-4 text-center text-dark fw-bolder my-4">Manager Panel</h2>
        <form id="form1" runat="server" class="mx-auto w-50">
            <div class="row">
                <div class="my-2">
                    <asp:Label ID="Label" runat="server" Text="Welcome," CssClass="form-label"></asp:Label>
                    <asp:Label ID="LabUsername" runat="server" CssClass="form-label text-success"></asp:Label>
                </div>
                <div class="my-2">
                    <asp:Label ID="LabId" runat="server" Text="User ID: " CssClass="form-label"></asp:Label>
                    <asp:Label ID="LabIdVal" runat="server" CssClass="form-label text-primary fw-bolder"></asp:Label>
                </div>
            </div>
            
            <div class="mt-4 form-group text-center row gap-2 mx-auto w-100">
                <asp:Button ID="BtnLogout" runat="server" Text="Logout" CssClass="btn btn-danger w-25" OnClick="BtnLogout_Click" />
            </div>

        </form>
    </div>
</asp:Content>