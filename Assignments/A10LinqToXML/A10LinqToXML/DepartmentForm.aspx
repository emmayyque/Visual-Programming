<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentForm.aspx.cs" Inherits="A10LinqToXML.DepartmentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <div class="container mt-4">
        <form id="form1" runat="server" class="w-75 mx-auto card border-1 rounded border-secondary">
            <h2 class="display-6 text-light text-center p-3 bg-dark fw-bolder">Department Form</h2>
            <div class="p-3">
                <div class="my-2 form-group">
                    <asp:Label ID="LabDepts" runat="server" Text="For Department Searching Only"></asp:Label>
                    <asp:DropDownList ID="DdlDepts" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabId" runat="server" Text="Please Enter Department ID"></asp:Label>
                    <asp:TextBox ID="TxtId" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabName" runat="server" Text="Please Enter Department Name"></asp:Label>
                    <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabNoOfEmp" runat="server" Text="Please Enter No. of Employees"></asp:Label>
                    <asp:TextBox ID="TxtNoOfEmp" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabLocation" runat="server" Text="Please Enter Department's Location"></asp:Label>
                    <asp:TextBox ID="TxtLocation" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabResult" runat="server"></asp:Label>
                </div>
                <div class="my-2 d-flex align-items-center justify-content-center gap-2">
                    <asp:Button ID="BtnInsert" runat="server" Text="Insert" CssClass="btn btn-primary" OnClick="BtnInsert_Click"/>
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-warning text-light" OnClick="BtnUpdate_Click"/>
                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="BtnDelete_Click"/>
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="BtnSearch_Click"/>
                    <asp:Button ID="BtnReset" runat="server" Text="Reset" CssClass="btn btn-secondary" OnClick="BtnReset_Click"/>
                </div>
            </div>
            <h2 class="display-7 text-light text-center p-3 bg-dark fw-bolder">Deparments List</h2>
            <div class="my-2">
                <asp:DataGrid ID="DataGridDepts" runat="server" CssClass="table table-bordered table-striped"></asp:DataGrid>
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
