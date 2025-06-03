<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserForm.aspx.cs" Inherits="StrProThreeTier.UserForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <div class="container">
         <form id="form1" runat="server" class="mx-auto w-50">
             <h2 class="text-center fw-bolder display-5">User Form</h2>
             <div class="my-2 col-12 row">
                 <div class="col-3">
                    <asp:Label ID="LabId" runat="server" Text="User ID"></asp:Label>
                    <asp:TextBox ID="TxtId" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
                 <div class="row col-6 align-items-end offset-3">
                    <div class="col-7">
                        <asp:Label ID="LabSrcUser" runat="server" Text="Select User"></asp:Label>
                        <asp:DropDownList ID="DdlUsers" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary mt-2 col-5 h-50 p-0" OnClick="BtnSearch_Click"/>
                 </div>
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
                 <asp:Label ID="ResultMsg" runat="server" ></asp:Label>
             </div>

             <div class="my-2 d-flex align-items-center justify-content-center gap-3">
                <asp:Button ID="BtnInsert" runat="server" Text="Insert" CssClass="btn btn-primary text-white" OnClick="BtnInsert_Click"/>
                <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-warning text-white" OnClick="BtnUpdate_Click"/>
                <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-danger text-white" OnClick="BtnDelete_Click"/>
             </div>
             <asp:DataGrid ID="GridUser" runat="server" CssClass="table table-bordered table-striped"></asp:DataGrid>
        </form>
    </div>
   
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
