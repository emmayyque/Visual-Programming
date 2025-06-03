<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="WFFirstProject.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="w-50 mx-auto mt-">
            <h2 class="display-6 text-dark text-center fw-semibold">User Registration</h2>
            <div class="my-2 form-group">
                <asp:Label ID="LabId" runat="server" Text="User Id"></asp:Label>
                <asp:TextBox ID="TxtId" runat="server" CssClass="form-control col-6"></asp:TextBox>
            </div>
            <div class="my-2 form-group"> 
                <asp:Label ID="LabName" runat="server" Text="Full Name"></asp:Label>
                <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="my-2 form-group">
                <asp:Label ID="LabEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="my-2 form-group">
                <asp:Button ID="BtnInsert" runat="server" CssClass="btn btn-primary" Text="Insert" OnClick="BtnInsert_Click"/>
                <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-dark" Text="Search" OnClick="BtnSearch_Click"/>
                <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-success" Text="Update" OnClick="BtnUpdate_Click"/>
                <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" OnClick="BtnDelete_Click"/>
            </div>
            <div class="my-2 form-group">
                <asp:Label ID="LabMessage" runat="server"></asp:Label>
            </div>

            <div class="mt-5">
                <asp:DataGrid ID="GridUsers" runat="server" CssClass="table table-bordered table-striped"></asp:DataGrid>
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
