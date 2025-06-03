<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CourseForm.aspx.cs" Inherits="A4WebForms.CourseForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
</head>
<body>
    <div class="container">
        <h2 class="display-6 text-dark text-center fw-semibold mt-4">Course Registration</h2>
        <form id="form1" runat="server" class="w-100 mx-auto mt-4 d-flex align-items-start justify-content-center gap-3">
            <div class="col-4">
                <div class="my-2 form-group">
                    <asp:Label ID="LabCourseCode" runat="server" Text="Course Code"></asp:Label>
                    <asp:TextBox ID="TxtCourseCode" runat="server" CssClass="form-control col-6"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabCourseName" runat="server" Text="Course Name"></asp:Label>
                    <asp:TextBox ID="TxtCourseName" runat="server" CssClass="form-control col-6"></asp:TextBox>
                </div>
                <div class="my-2 form-group"> 
                    <asp:Label ID="LabCreditHours" runat="server" Text="Credit Hours"></asp:Label>
                    <asp:TextBox ID="TxtCreditHours" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group"> 
                    <asp:Label ID="LabDuration" runat="server" Text="Duration"></asp:Label>
                    <asp:TextBox ID="TxtDuration" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabCourseLevel" runat="server" Text="Course Level"></asp:Label>
                    <asp:DropDownList ID="DdlCourseLevel" runat="server" CssClass="form-control">
                        <asp:ListItem Enabled="true" Value="-1" Text="Select Level"></asp:ListItem>
                        <asp:ListItem Value="Beginner" Text="Beginner"></asp:ListItem>
                        <asp:ListItem Value="Intermediate" Text="Intermediate"></asp:ListItem>
                        <asp:ListItem Value="Advanced" Text="Advanced"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabPrerequisites" runat="server" Text="Prerequisites"></asp:Label>
                    <asp:TextBox ID="TxtPrerequisites" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabCourseFee" runat="server" Text="Course Fee"></asp:Label>
                    <asp:TextBox ID="TxtCourseFee" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="my-2 form-group">
                    <asp:Label ID="LabInstructorName" runat="server" Text="Instructor Name"></asp:Label>
                    <asp:TextBox ID="TxtInstructorName" runat="server" CssClass="form-control"></asp:TextBox>
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
                <asp:DataGrid ID="GridCourses" runat="server" CssClass="table table-bordered table-striped"></asp:DataGrid>
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
