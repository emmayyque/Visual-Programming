<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="WebFormSMS.ProductForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <div class="container">
        <form id="form1" runat="server" class="col-8 mx-auto">
            <h2 class="display-4 fw-bolder text-center my-5 text-uppercase">Product Form</h2>
            <div class="row">
                <div class="col-6">
                    <div class="row my-2 col-12 justify-content-between">
                        <div class="col-3 form-group">
                            <asp:Label ID="LabID" runat="server" Text="Product ID"></asp:Label>
                            <asp:TextBox ID="TxtID" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="d-flex align-items-center justify-content-between col-7 form-group mt-4 mx-0 p-0 gap-2">
                            <asp:DropDownList ID="DdlProducts" runat="server" CssClass="w-75 form-control"></asp:DropDownList>
                            <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary col-5" OnClick="BtnSearch_Click"/>
                        </div>
                    </div>
                    <div class="my-2 form-group">
                        <asp:Label ID="LabName" runat="server" Text="Product Name"></asp:Label>
                        <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="my-2 form-group">
                        <asp:Label ID="LabBrand" runat="server" Text="Product Brand"></asp:Label>
                        <asp:TextBox ID="TxtBrand" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="my-2 form-group">
                        <asp:Label ID="LabPrice" runat="server" Text="Product Price"></asp:Label>
                        <asp:TextBox ID="TxtPrice" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="my-2 form-group">
                        <asp:Label ID="LabQuantity" runat="server" Text="Product Quantity"></asp:Label>
                        <asp:TextBox ID="TxtQuantity" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="my-2 form-group">
                        <asp:Label ID="LabResult" runat="server"></asp:Label>
                    </div>
                    <div class="my-2 form-group">
                        <asp:Button ID="BtnInsert" runat="server" Text="Insert" CssClass="btn btn-primary" OnClick="BtnInsert_Click"/>
                        <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-success" OnClick="BtnUpdate_Click"/>
                        <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-warning text-white" OnClick="BtnDelete_Click"/>
                    </div>
                </div>
                <div class="col-6 mt-4">
                    <asp:DataGrid ID="GridProducts" runat="server" CssClass="table table-bordered table-striped"></asp:DataGrid>
                </div>
            </div>            
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
