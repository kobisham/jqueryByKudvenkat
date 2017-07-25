<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeGetFromWCF.aspx.cs" Inherits="jQueryWeb.EmployeeGetFromWCF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script src="https://code.jquery.com/jquery-2.2.4.js"
            integrity="sha256-iT6Q9iMJYuQiMWNd9lDyBUStIq/8PuOW33aOqmvFpqI="
            crossorigin="anonymous"></script>
    <title></title>
    <script>
        $(document).ready(function () {
            $("#btnGetEmployee").click(function () {
                var empId = $("#txtId").val();
                $.ajax({
                    method: "POST",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    url: "EmployeeServiceWCF.svc/GetEmployeeByIdWCF",
                    data: JSON.stringify({ employeeId: empId }),
                    success: function (response) {
                        $("#txtName").val(response.d.Name);
                        $("#txtGender").val(response.d.Gender);
                        $("#txtSalary").val(response.d.Salary);
                    },
                    error: function (err)
                    {
                        alert(err.statusText);
                    }
                });
            });
        });


    </script>
</head>
<body style="font-family:Arial">
    ID :
    <input id="txtId" type="text" style="width: 86px" />
    <input type="button" id="btnGetEmployee" value="Get Employee" />
    <br /><br />
    <table border="1" style="border-collapse: collapse">
        <tr>
            <td>Name</td>
            <td><input id="txtName" type="text" /></td>
        </tr>
        <tr>
            <td>Gender</td>
            <td><input id="txtGender" type="text" /></td>
        </tr>
        <tr>
            <td>Salary</td>
            <td><input id="txtSalary" type="text" /></td>
        </tr>
    </table>
</body>
</html>
