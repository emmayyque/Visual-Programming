<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentForm.aspx.cs" Inherits="A6WebFormsSP.StudentForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <div class="container">
        <h2 class="display-6 text-dark text-center fw-semibold mt-4">Student Registration</h2>
        <form id="form1" runat="server" class="w-100 mx-auto mt-4 d-flex align-items-start justify-content-center gap-3">
            <div class="col-4">
                <div class="my-2 form-group">
                    <asp:Label ID="LabRollNo" runat="server" Text="Roll No"></asp:Label>
                    <asp:TextBox ID="TxtRollNo" runat="server" CssClass="form-control col-6"></asp:TextBox>
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
                    <asp:Label ID="LabFatherName" runat="server" Text="Father Name"></asp:Label>
                    <asp:TextBox ID="TxtFatherName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabSysId" runat="server" Text="System ID"></asp:Label>
                    <asp:TextBox ID="TxtSysId" runat="server" CssClass="form-control"></asp:TextBox>
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
                    <asp:Label ID="LabDOA" runat="server" Text="Date of Admission"></asp:Label>
                    <asp:TextBox ID="TxtDOA" runat="server" type="date" CssClass="form-control"></asp:TextBox>
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
                <asp:DataGrid ID="GridStudents" runat="server" CssClass="table table-bordered table-striped"></asp:DataGrid>
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
