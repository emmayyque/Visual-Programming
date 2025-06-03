<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="A8Authentication_AuthCLA.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageTitle" runat="server">
    Login
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PageBody" runat="server">
    <div class="container mt-5">
        <h2 class="display-4 text-center text-dark fw-bolder my-4">Login Form</h2>
        <form id="form1" runat="server" class="mx-auto w-50">
            <div class="my-2 form-group">
                <asp:Label ID="LabUsername" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="TxtUsername" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="my-2 form-group">
                <asp:Label ID="LabPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mt-4 form-group text-center">
                <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="btn btn-success w-25" OnClick="BtnLogin_Click"/>
            </div>
        </form>
    </div>
</asp:Content>