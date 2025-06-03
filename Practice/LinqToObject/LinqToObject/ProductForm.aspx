<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="LinqToObject.ProductForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
</head>
<body>
    <div class="container mt-5">
        <div class="card shadow-sm p-3 mt-2">
            <form id="form1" runat="server">
                <h2 class="display-5 fw-bolder text-center">Product Form</h2>
                <h2 class="display-7 fw-bolder text-center">(Linq To Object)</h2>
                <div class="form-group my-2">
                    <asp:Label ID="LabSelectProduct" runat="server" Text="Select to Search Product"></asp:Label>
                    <asp:DropDownList ID="DdlProduct" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabID" runat="server" Text="Enter Product ID"></asp:Label>
                    <asp:TextBox ID="TxtID" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabName" runat="server" Text="Enter Product Name"></asp:Label>
                    <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabDescription" runat="server" Text="Enter Product Description"></asp:Label>
                    <asp:TextBox ID="TxtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group my-2">
                    <asp:Label ID="LabQuantity" runat="server" Text="Enter Product Quantity"></asp:Label>
                    <asp:TextBox ID="TxtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2">
                    <asp:Label ID="LabResult" runat="server"></asp:Label>
                </div>
                <div class="form-group my-2 mt-4 d-flex align-items-center justify-content-center gap-3">
                    <asp:Button ID="BtnInsert" runat="server" Text="Insert" CssClass="btn btn-primary" OnClick="BtnInsert_Click" />
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-warning text-light" OnClick="BtnUpdate_Click" />
                    <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" OnClick="BtnDelete_Click" />
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="BtnSearch_Click" />
                </div>
                <hr />
                <div class="mt-2">
                    <h2 class="display-5 fw-bolder text-center">Products List</h2>
                    <asp:DataGrid ID="GridProducts" runat="server" CssClass="table table-striped table-bordered"></asp:DataGrid>
                </div>
            </form>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>