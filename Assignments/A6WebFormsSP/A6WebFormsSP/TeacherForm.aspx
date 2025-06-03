<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherForm.aspx.cs" Inherits="A6WebFormsSP.TeacherForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Teacher Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <div class="container">
        <h2 class="display-6 text-dark text-center fw-semibold mt-4">Teacher Registration</h2>
        <form id="form1" runat="server" class="w-100 mx-auto mt-4 d-flex align-items-start justify-content-center gap-3">
            <div class="col-4">
                <div class="my-2 form-group">
                    <asp:Label ID="LabId" runat="server" Text="Teacher ID"></asp:Label>
                    <asp:TextBox ID="TxtId" runat="server" CssClass="form-control col-6"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabFirstName" runat="server" Text="First Name"></asp:Label>
                    <asp:TextBox ID="TxtFirstName" runat="server" CssClass="form-control col-6"></asp:TextBox>
                </div>
                <div class="my-2 form-group"> 
                    <asp:Label ID="LabLastName" runat="server" Text="Last Name"></asp:Label>
                    <asp:TextBox ID="TxtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group"> 
                    <asp:Label ID="LabExperience" runat="server" Text="Experience"></asp:Label>
                    <asp:TextBox ID="TxtExperience" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabType" runat="server" Text="Type"></asp:Label>      
                    <asp:DropDownList ID="DdlType" runat="server" CssClass="form-control">
                        <asp:ListItem Enabled="True" value="-1" Text="Select Type"></asp:ListItem>
                        <asp:ListItem value="Contract" Text="Contract"></asp:ListItem>
                        <asp:ListItem value="Permanent" Text="Permanent"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabAddress" runat="server" Text="Address"></asp:Label>
                    <asp:TextBox ID="TxtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabDOB" runat="server" Text="Date of Birth"></asp:Label>
                    <asp:TextBox ID="TxtDOB" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabDOJ" runat="server" Text="Date of Joining"></asp:Label>
                    <asp:TextBox ID="TxtDOJ" runat="server" type="date" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-3 form-group">
                    <asp:Button ID="BtnInsert" runat="server" CssClass="btn btn-primary" Text="Insert" OnClick="BtnInsert_Click" />
                    <asp:Button ID="BtnSearch" runat="server" CssClass="btn btn-dark" Text="Search" OnClick="BtnSearch_Click" />
                    <asp:Button ID="BtnUpdate" runat="server" CssClass="btn btn-success" Text="Update" OnClick="BtnUpdate_Click" />
                    <asp:Button ID="BtnDelete" runat="server" CssClass="btn btn-danger" Text="Delete" OnClick="BtnDelete_Click" />
                </div>

                <div class="my-2 form-group">
                    <asp:Label ID="LabMessage" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-6">
                <asp:Button ID="BtnMain" runat="server" CssClass="btn btn-primary mb-3 align-self-end" Text="Main Page" OnClick="BtnMain_Click" />
                <asp:DataGrid ID="GridTeachers" runat="server" CssClass="table table-bordered table-striped"></asp:DataGrid>
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
