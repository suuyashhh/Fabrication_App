<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fab_Admin_History.aspx.cs" Inherits="WebApplication1.Fab_Admin_History" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Admin Salary Slip History</title>

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Saira:wght@400;500;600&display=swap" rel="stylesheet" />

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
                <img src="FabImage/SalaryHistory.png" alt="Doctor Icon" height="50" class="me-2" />
                <h1>Admin Salary Slip History</h1>
            </div>

            <div class="content">


                <!-- Salary Slip Section -->
                <div class="row justify-content-center mt-5">
                    <div class="col-12 col-md-10">
                        <div class="card shadow">
                            <div class="card-body">
                                <div class="row g-3">
                                    <div class="col-md-4">
                                        <strong>HELPER NAME:</strong><br />
                                        <span>__________________</span><br />
                                    </div>
                                    <div class="col-md-4">
                                        <strong>From Date:</strong> <span id="fromDateSpan" runat="server"></span>
                                        <br />
                                        <strong>To Date:</strong> <span id="toDateSpan" runat="server"></span>
                                    </div>
                                    <div class="col-md-4 text-end">
                                        <strong>Salary Date:</strong><br />
                                        <span id="slipDaySpan" runat="server"></span>
                                        <br />
                                    </div>


                                </div>
                            </div>
                            <div class="card-body text-center">
                                <h5><strong>SALARY SLIP FOR THE MONTH OF -</strong></h5>
                            </div>
                            <div class="table-responsive">


                                <asp:Repeater ID="HistoryAttendanceSummary" runat="server">
                                    <HeaderTemplate>
                                        <table class="table table-bordered">
                                            <thead class="table-light">
                                                <tr>
                                                    <th></th>
                                                    <th>Days</th>
                                                    <th>Salary</th>
                                                    <th>Total Salary</th>
                                                    <th>Action</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td>FULL DAY</td>
                                            <td><%# Eval("Full_Day") %></td>
                                            <td><%# Eval("Full_Salary") %></td>
                                            <td><%# Eval("Full_day_Total") %></td>
                                            <td rowspan="5" class="text-center align-middle">
                                                <asp:Label runat="server" ID="AShistory" Style="display: none" Text='<%# Eval("Slip_id") %>'></asp:Label>
                                                <asp:LinkButton runat="server" ID="RepeterDelete"
                                                    OnClientClick="return confirm('Do you want to delete this Item?')"
                                                    OnClick="RepeterDelete_Click"
                                                    Style="background-color: orange; color: white; padding: 10px; border-radius: 5px;">
                                                <span class="fa fa-trash"></span> Delete
                                            </asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>HALF DAY</td>
                                            <td><%# Eval("Half_Day") %></td>
                                            <td><%# Eval("Half_Salary")%></td>
                                            <td><%# Eval("Half_day_Total")%></td>
                                        </tr>
                                        <tr>
                                            <td>OFF DAY</td>
                                            <td><%# Eval("Off_Day") %></td>
                                            <td>0</td>
                                            <td>0</td>
                                        </tr>
                                        <tr>
                                            <td>ADVANCE</td>
                                            <td></td>
                                            <td><%# Eval("Advance_Salary") %></td>
                                            <td><%# Eval("Advance_Total") %></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"><strong>TOTAL</strong></td>
                                            <td>
                                                <%# Eval("Grand_Total") %>
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
         window.location.href = 'Fab_Admin_SalaryHistory.aspx';
     };

     </script>


    <!-- Bootstrap JS -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/js/bootstrap.bundle.min.js"></script>

</body>
</html>
