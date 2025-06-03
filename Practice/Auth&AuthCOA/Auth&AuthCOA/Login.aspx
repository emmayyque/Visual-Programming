<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Auth_AuthCOA.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Login Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <div class="container mt-3">
        <form id="form1" runat="server">
            <div class="card border-1 shadow-lg p-3">
                <h2 class="display-6 fw-bolder text-center text-light bg-dark p-2">Login Form</h2>
                <div class="form-group my-2">
                    <asp:Label ID="LabUsername" runat="server" Text="Enter Username"></asp:Label>
                    <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabPassword" runat="server" Text="Enter Password"></asp:Label>
                    <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="d-flex align-items-center justify-content-center">
                    <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="btn btn-primary w-25" OnClick="BtnLogin_Click" />
                </div>
            </div>
        </form>
    </div>
</asp:Content>
