<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesForm.aspx.cs" Inherits="LINQToXML.EmployeesForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <div class="container mt-3 w-50">
        <form id="form1" runat="server">
            <div class="card p-3">
                <h2 class="mt-2 display-6 fw-bolder text-center bg-dark text-white py-2">Registration Form</h2>
                <div class="form-group my-2">
                    <asp:Label ID="LabSelectEmployee" runat="server" Text="Select Employee"></asp:Label>
                    <asp:DropDownList ID="DdlEmployees" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabID" runat="server" Text="ID"></asp:Label>
                    <asp:TextBox ID="TxtID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabFullName" runat="server" Text="Full Name"></asp:Label>
                    <asp:TextBox ID="TxtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabEmail" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabAge" runat="server" Text="Age"></asp:Label>
                    <asp:TextBox ID="TxtAge" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 d-flex justify-content-center align-item-center gap-3">
                    <asp:Button ID="BtnInsert" runat="server" Text="Insert" CssClass="btn btn-primary" OnClick="BtnInsert_Click"/>
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="BtnUpdate_Click"/>
                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="BtnDelete_Click"/>
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="BtnSearch_Click"/>
                    <asp:Button ID="BtnReset" runat="server" Text="Reset" CssClass="btn btn-warning text-white"/>
                </div>
            </div>
            <div class="mt-4">
                <h2 class="mt-2 display-6 fw-bolder text-center bg-dark text-white py-2">Employees List</h2>
                <asp:DataGrid ID="GridEmployees" runat="server" CssClass="table table-bordered table-striped"></asp:DataGrid>
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
