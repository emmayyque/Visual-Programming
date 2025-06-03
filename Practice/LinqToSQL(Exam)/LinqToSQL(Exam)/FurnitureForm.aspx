<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FurnitureForm.aspx.cs" Inherits="LinqToSQL_Exam_.FurnitureForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Furniture Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <div class="container mt-4">
        <div class="card p-2 shadow-sm">
            <form id="form1" runat="server">
                <h2 class="display-6 fw-bolder text-center text-light bg-dark p-3">Furniture Form</h2>
                <div class="my-2 form-group">
                    <asp:Label ID="LabSelectFurniture" runat="server" Text="Select Furniture"></asp:Label>
                    <asp:DropDownList ID="DdlFurniture" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabTypeOfFurniture" runat="server" Text="Furniture Type"></asp:Label>
                    <asp:TextBox ID="TxtTypeOfFurniture" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabColor" runat="server" Text="Furniture Color"></asp:Label>
                    <asp:TextBox ID="TxtColor" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabSeatingCapacity" runat="server" Text="Seating Capacity"></asp:Label>
                    <asp:TextBox ID="TxtSeatingCapacity" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2">
                    <asp:Label ID="LabResult" runat="server"></asp:Label>
                </div>
                <hr />
                <div class="my-2 d-flex align-items-center justify-content-center gap-2">
                    <asp:Button ID="BtnInsert" runat="server" CssClass="btn btn-primary" Text="Insert" OnClick="BtnInsert_Click"></asp:Button>
                    <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-warning text-light" Text="Update" OnClick="BtnUpdate_Click"></asp:Button>
                    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" OnClick="BtnDelete_Click"></asp:Button>
                    <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="BtnSearch_Click"></asp:Button>
                </div>
                <hr />
                <div class="my-2">
                    <h2 class="display-6 fw-bolder text-center text-light bg-dark p-3">Furnitures List</h2>
                    <asp:DataGrid ID="GridFurnitures" runat="server" CssClass="table table-striped table-bordered"></asp:DataGrid>
                </div>
            </form>
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>