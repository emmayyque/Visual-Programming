<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="A4WebForms.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Course Form</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
</head>
<body>
    <div class="container">
        <h2 class="display-6 text-dark text-center fw-semibold mt-4">Management System</h2>
        <form id="form1" runat="server" class="w-100 mx-auto mt-4">
            <p class="text-center mt-5 mb-3">
                Select a form<br />
                You wish to enter data for....
            </p>
            <div class="d-flex align-items-center justify-content-center gap-3 flex-column w-75 mx-auto">
                <asp:Button ID="BtnStudent" runat="server" CssClass="btn btn-primary w-25" Text="Student Form" OnClick="BtnStudent_Click"/>
                <asp:Button ID="BtnTeacher" runat="server" CssClass="btn btn-warning text-light w-25" Text="Teacher Form" OnClick="BtnTeacher_Click"/>
                <asp:Button ID="BtnCourse" runat="server" CssClass="btn btn-success w-25" Text="Course Form" OnClick="BtnCourse_Click"/>
            </div>
        </form>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>