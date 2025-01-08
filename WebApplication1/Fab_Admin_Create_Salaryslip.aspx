<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fab_Admin_Create_Salaryslip.aspx.cs" Inherits="WebApplication1.Fab_Admin_Create_Salaryslip" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Create Salary Slip</title>

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Saira:wght@400;500;600&display=swap" rel="stylesheet" />

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>


    <!-- Sweet Alert -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" />

    <!-- Custom Styles -->
    <style>
        body, html {
            margin: 0;
            padding: 0;
            font-family: "Saira", sans-serif;
        }

        .header {
            background-color: #f8f9fa;
            padding: 15px 20px;
            border-bottom: 1px solid #ddd;
            position: fixed;
            top: 0;
            width: 100%;
            z-index: 1000;
        }

            .header h1 {
                font-size: 24px;
                margin: 0;
                color: #495057;
            }

        .content {
            padding: 100px 15px 20px;
        }

        .btn-submit {
            background-color: #0d6efd;
            color: white;
            padding: 10px 20px;
            border-radius: 5px;
            border: none;
        }

            .btn-submit:hover {
                background-color: #0a58ca;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <!-- Header Section -->
            <div class="header d-flex align-items-center">
                <img src="FabImage/AdminCreateSalaySlip.png" alt="Doctor Icon" height="50" class="me-2" />
                <h1>Create Salary Slip</h1>
            </div>

            <div class="content">
                <!-- Date Selection Section -->
                <div class="row justify-content-center">
                    <div class="col-12 col-md-8 col-lg-6">
                        <div class="card shadow-sm p-4">
                            <div class="row g-3">
                                <div class="col-md-6">
                                    <label for="fromDate" class="form-label">From Date*</label>
                                    <asp:TextBox ID="fromDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="toDate" class="form-label">To Date*</label>
                                    <asp:TextBox ID="toDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="text-center mt-4">
                                <asp:Button ID="btnSearchDatePE" Text="Search" OnClientClick="return valid()" CssClass="btn btn-submit" runat="server" OnClick="btnSearchDatePE_Click" />


                                <%--<asp:Button ID="btnSearchDatePE" OnClientClick="return valid()" Text="Search" CssClass="btn btn-submit" runat="server" />--%>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Salary Slip Section -->
                <div class="row justify-content-center mt-5">
                    <div class="col-12 col-md-10">
                        <div class="card shadow">
                            <div class="card-body">
                                <div class="row g-3">
                                    <div class="col-md-4">
                                        <strong>HELPER NAME:</strong><br />
                                        <asp:DropDownList ID="ddlHelpername" runat="server" CssClass="form-control form-control-sm"
                                            DataTextField="User_name" DataValueField="User_name" Style="width: 150px;">
                                            <asp:ListItem Text="--Select Helper--" Value="" Selected="True"></asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                    <div class="col-md-4">
                                        <strong>From Date:</strong> <span id="fromDateSpan">N/A</span><br />
                                        <strong>To Date:</strong> <span id="toDateSpan">N/A</span>
                                    </div>
                                    <div class="col-md-4 text-end">
                                        <asp:Button ID="btnSave" runat="server" OnClientClick="return validS()" OnClick="btnSave_Click" Text="Save" CssClass="btn btn-primary" />
                                    </div>
                                </div>
                            </div>
                            <div class="card-body text-center">
                                <h5><strong>SALARY SLIP FOR THE MONTH OF -</strong></h5>
                            </div>
                            <div class="table-responsive">

                               <asp:Repeater ID="rptAttendanceSummary" runat="server">
    <HeaderTemplate>
        <table class="table table-bordered">
            <thead class="table-light">
                <tr>
                    <th></th>
                    <th>Days</th>
                    <th>Salary</th>
                    <th>Total Salary</th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>FULL DAY</td>
            <td>
                <asp:Label ID="fullDayCount" runat="server" Text='<%# Eval("FullDay_Count") %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="fullDaySalary" runat="server" CssClass="form-control salary-input"
                    Text='<%# Eval("User_salary") %>' AutoPostBack="true" OnTextChanged="CalculateSalary" data-type="fullDay"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="fullDayTotal" runat="server" Text='<%# Convert.ToDecimal(Eval("FullDay_Count")) * Convert.ToDecimal(Eval("User_salary")) %>'></asp:Label>
            </td>
        </tr>
        <tr>
            <td>HALF DAY</td>
            <td>
                <asp:Label ID="halfDayCount" runat="server" Text='<%# Eval("HalfDay_Count") %>'></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="halfDaySalary" runat="server" CssClass="form-control salary-input"
                    Text='<%# (Convert.ToDecimal(Eval("User_salary")) / 2) %>' AutoPostBack="true" OnTextChanged="CalculateSalary" data-type="halfDay"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="halfDayTotal" runat="server" Text='<%# (Convert.ToDecimal(Eval("HalfDay_Count")) * Convert.ToDecimal(Eval("User_salary")) / 2) %>'></asp:Label>
            </td>
        </tr>
        <tr>
            <td>OFF DAY</td>
            <td>
                <asp:Label ID="offDayCount" runat="server" Text='<%# Eval("OffDay_Count") %>'></asp:Label>
            </td>
            <td>0</td>
            <td>0</td>
        </tr>
        <tr>
            <td>ADVANCE</td>
            <td></td>
            <td>
                <asp:TextBox ID="advanceAmount" runat="server" CssClass="form-control advance-input"
                    Text='<%# Eval("TOTAL_ADVANCE") %>' AutoPostBack="true" OnTextChanged="CalculateSalary" data-type="advance"></asp:TextBox>
            </td>
            <td>
                <asp:Label ID="advanceTotal" runat="server" Text='<%# Eval("TOTAL_ADVANCE") %>'></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="3"><strong>TOTAL</strong></td>
            <td>
                <asp:Label ID="grandTotal" runat="server" Text='<%# (Convert.ToDecimal(Eval("FullDay_Count")) * Convert.ToDecimal(Eval("User_salary")) 
                + (Convert.ToDecimal(Eval("HalfDay_Count")) * Convert.ToDecimal(Eval("User_salary")) / 2)
                - Convert.ToDecimal(Eval("TOTAL_ADVANCE"))) %>'></asp:Label>
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </tbody>
       </table>
    </FooterTemplate>
</asp:Repeater>




                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>



    <script>
        $(document).ready(function () {
            $(".salary-input, .advance-input").on("input", function () {
                const parentCard = $(this).closest(".card-body");

                // Fetch the required values
                const fullDayCount = parseInt(parentCard.find("[id$=fullDayCount]").text()) || 0;
                const halfDayCount = parseInt(parentCard.find("[id$=halfDayCount]").text()) || 0;
                const fullDaySalary = parseFloat(parentCard.find("[id$=fullDaySalary]").val()) || 0;
                const halfDaySalary = parseFloat(parentCard.find("[id$=halfDaySalary]").val()) || 0;
                const advanceAmount = parseFloat(parentCard.find("[id$=advanceAmount]").val()) || 0;

                // Calculate totals
                const fullDayTotal = fullDayCount * fullDaySalary;
                const halfDayTotal = halfDayCount * halfDaySalary;
                const grandTotal = fullDayTotal + halfDayTotal - advanceAmount;

                // Update the corresponding UI elements
                parentCard.find("[id$=fullDayTotal]").text(fullDayTotal.toFixed(2));
                parentCard.find("[id$=halfDayTotal]").text(halfDayTotal.toFixed(2));
                parentCard.find("[id$=advanceTotal]").text(advanceAmount.toFixed(2));
                parentCard.find("[id$=grandTotal]").text(grandTotal.toFixed(2));

                // AJAX call to server-side method
                $.ajax({
                    type: "POST",
                    url: "Fab_Admin_Create_Salaryslip.aspx/CalculateSalary",
                    contentType: "application/json; charset=utf-8",
                    data: JSON.stringify({
                        fullDayCount: fullDayCount,
                        fullDaySalary: fullDaySalary,
                        halfDayCount: halfDayCount,
                        halfDaySalary: halfDaySalary,
                        advanceAmount: advanceAmount
                    }),
                    dataType: "json",
                    success: function (response) {
                        // Update the calculated values in the UI
                        const data = response.d;
                        parentDiv.find("#fullDayTotal").text(data.FullDayTotal.toFixed(2));
                        parentDiv.find("#halfDayTotal").text(data.HalfDayTotal.toFixed(2));
                        parentDiv.find("#advanceTotal").text(data.AdvanceTotal.toFixed(2));
                        parentDiv.find("#grandTotal").text(data.GrandTotal.toFixed(2));
                    },
                    error: function (xhr, status, error) {
                        console.error("AJAX Error: " + status + " - " + error);
                    }
                });
            });
        });

    </script>


    <script>
        window.addEventListener('load', function () {
            const fromDate = document.getElementById('<%= fromDate.ClientID %>').value;
            const toDate = document.getElementById('<%= toDate.ClientID %>').value;

            document.getElementById('fromDateSpan').innerText = fromDate || 'N/A';
            document.getElementById('toDateSpan').innerText = toDate || 'N/A';
        });

        function valid() {
            const fromdate = document.getElementById('<%= fromDate.ClientID %>').value;
            const todate = document.getElementById('<%= toDate.ClientID %>').value;
            const ddlHelper = document.getElementById('<%= ddlHelpername.ClientID %>');

            if (!fromdate || !todate) {
                swal("Please fill The Date to proceed..!", "", "error");
                return false;
            } else if (ddlHelper.selectedIndex === 0) {
                swal("Please select a Helper!", "", "error");
                return false;
            }

            const fromDateObj = new Date(fromdate);
            const toDateObj = new Date(todate);

            if (fromDateObj > toDateObj) {
                swal("From Date cannot be later than To Date!", "", "warning");
                return false;
            }

            return true;
        }

        function validS() {
            const fromdate = document.getElementById('<%= fromDate.ClientID %>').value;
            const todate = document.getElementById('<%= toDate.ClientID %>').value;
            const ddlHelper = document.getElementById('<%= ddlHelpername.ClientID %>');

            if (!fromdate || !todate) {
                swal("Please fill The Date to proceed..!", "", "error");
                return false;
            } else if (ddlHelper.selectedIndex === 0) {
                swal("Please select a Helper!", "", "error");
                return false;
            }

            if (!fromdate || !todate) {
                swal("Please fill The Date to proceed..!", "", "error");
                return false;
            }

            const fromDateObj = new Date(fromdate);
            const toDateObj = new Date(todate);

            if (fromDateObj > toDateObj) {
                swal("From Date cannot be later than To Date!", "", "warning");
                return false;
            }

            return true;
        }



    </script>


     <script>
         window.addEventListener('load', function () {
             if (history.state === null) {
                 history.pushState({}, 'Monthly', window.location.href);
             }

             const img = document.querySelector('.header img');
             const h1 = document.querySelector('.header h1');

             img.style.transition = 'transform 1s ease-in-out';
             h1.style.transition = 'transform 1s ease-in-out 0.2s';

             img.style.transform = 'translateX(0)';
             h1.style.transform = 'translateX(0)';
         });

         window.addEventListener('DOMContentLoaded', function () {
             const img = document.querySelector('.header img');
             const h1 = document.querySelector('.header h1');

             img.style.transform = 'translateX(100%)';
             h1.style.transform = 'translateX(100%)';
         });

         window.addEventListener('load', function () {
             function animateMonthBoxes() {
                 const monthBoxes = document.querySelectorAll('.month-box');
                 monthBoxes.forEach((box, index) => {
                     setTimeout(() => {
                         box.classList.add('active');
                     }, index * 300);
                 });
             }
             animateMonthBoxes();
         });

         window.onpopstate = function (event) {
             window.location.href = 'Fabrication_Admin.aspx';
         };

     </script>

</body>
</html>

