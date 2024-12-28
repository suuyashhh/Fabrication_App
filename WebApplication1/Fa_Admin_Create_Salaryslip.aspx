<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fa_Admin_Create_Salaryslip.aspx.cs" Inherits="WebApplication1.Fab_Admin_Create_Salaryslip" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Monthly Attendance Management</title>

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
                <img src="FabImage/calendar_4310927.png" alt="Doctor Icon" height="50" class="me-2" />
                <h1>Monthly Attendance Management</h1>
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
                                <asp:Button ID="btnSearchDatePE" Text="Search" CssClass="btn btn-submit" runat="server" OnClick="btnSearchDatePE_Click" />


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
                                        <asp:DropDownList ID="ddlHelpername" runat="server" CssClass="form-control form-control-sm" DataTextField="User_name" DataValueField="User_name" Style="width: 150px;"></asp:DropDownList>

                                    </div>
                                    <div class="col-md-4">
                                        <strong>From Date:</strong> <span id="fromDateSpan">N/A</span><br />
                                        <strong>To Date:</strong> <span id="toDateSpan">N/A</span>
                                    </div>
                                    <div class="col-md-4 text-end">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" />
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
                                            <td><%# Eval("FullDay_Count") %>
                                            </td>
                                            <td>
                                                <input type="text" class="form-control"
                                                    value="<%# Eval("User_salary") %>"
                                                    id="fullDayCount_<%# Container.ItemIndex %>" />

                                                <td><%# Convert.ToDecimal(Eval("FullDay_Count")) * Convert.ToDecimal(Eval("User_salary")) %></td>
                                        </tr>
                                        <tr>
                                            <td>HALF DAY</td>
                                            <td><%# Eval("HalfDay_Count") %>
                                            </td>
                                            <td>
                                                <input type="text" class="form-control"
                                                    value="<%#(Convert.ToDecimal(Eval("User_salary")) / 2) %>"
                                                    id="halfDayCount_<%# Container.ItemIndex %>" />
                                                <td><%# (Convert.ToDecimal(Eval("HalfDay_Count")) * Convert.ToDecimal(Eval("User_salary")) / 2) %></td>
                                        </tr>
                                        <tr>
                                            <td>OFF DAY</td>
                                            <td><%# Eval("OffDay_Count") %></td>
                                            <td>0</td>
                                            <td>0</td>
                                        </tr>
                                        <tr>
                                            <td>ADVANCE</td>
                                            <td></td>
                                            <td>
                                                <input type="text" class="form-control"
                                                    value="<%# Eval("TOTAL_ADVANCE") %>"
                                                    id="totalAdvance_<%# Container.ItemIndex %>" />
                                            </td>
                                            <td>-<%# Eval("TOTAL_ADVANCE") %></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3"><strong>TOTAL</strong></td>
                                            <td>
                                                <%# (Convert.ToDecimal(Eval("FullDay_Count")) * Convert.ToDecimal(Eval("User_salary")) 
                     + (Convert.ToDecimal(Eval("HalfDay_Count")) * Convert.ToDecimal(Eval("User_salary")) / 2)
                     - Convert.ToDecimal(Eval("TOTAL_ADVANCE"))) %>
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
        window.addEventListener('load', function () {
            const fromDate = document.getElementById('<%= fromDate.ClientID %>').value;
            const toDate = document.getElementById('<%= toDate.ClientID %>').value;

            document.getElementById('fromDateSpan').innerText = fromDate || 'N/A';
            document.getElementById('toDateSpan').innerText = toDate || 'N/A';
        });

        function valid() {
            const fromdate = document.getElementById('<%= fromDate.ClientID %>').value;
            const todate = document.getElementById('<%= toDate.ClientID %>').value;

            if (!fromdate || !todate) {
                swal("Please fill all details to proceed..!", "", "error");
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
</body>
</html>

