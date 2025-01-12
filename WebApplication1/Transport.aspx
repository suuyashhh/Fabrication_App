<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transport.aspx.cs" Inherits="WebApplication1.Transport" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Transport List</title>

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
            display: flex;
            justify-content: flex-start;
            align-items: center;
            padding: 15px 20px;
            background-color: #f8f9fa;
            border-bottom: 1px solid #ddd;
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            z-index: 1000;
        }

            .header img {
                height: 50px;
                margin-right: 10px;
            }

            .header h1 {
                font-size: 24px;
                margin: 0;
                color: #495057;
            }

        .content {
            padding: 120px 15px 20px;
        }

        .month-box {
            opacity: 0;
            transform: translateY(50px);
            transition: opacity 0.6s ease-out, transform 0.6s ease-out;
        }

            .month-box.active {
                opacity: 1;
                transform: translateY(0);
            }

        .btn-submit {
            background-color: #0d6efd;
            border: none;
            color: white;
            padding: 10px 20px;
            font-size: 16px;
            border-radius: 5px;
            cursor: pointer;
        }

            .btn-submit:hover {
                background-color: #0a58ca;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <div class="header">
                <img src="FabImage/TransportList.png" alt="Doctor Icon" />
                <h1>Transport List</h1>
            </div>

            <div class="content">
                <div class="row justify-content-center">
                    <div class="col-md-6 month-box">
                        <div class="card shadow-sm p-4">
                            <div class="row">
                                <div class="col-12 col-md-6">
                                    <label for="fromDate" class="form-label">From Date*</label>
                                    <asp:TextBox ID="fromDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-12 col-md-6">
                                    <label for="toDate" class="form-label">To Date*</label>
                                    <asp:TextBox ID="toDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mt-4">
                                <div class="col text-center">
                                    <asp:Button ID="btnSearchDate" OnClick="btnSearchDate_Click" OnClientClick="return valid()" Text="Search" CssClass="btn btn-submit" runat="server" />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="card shadow mt-5 month-box">

                    <div class="card-body">
                        <div class="row g-3">
                            <div class="col-md-4">
                                <span style="color: red">TRANSPORT:</span>
                            </div>
                            <div class="col-md-4">
                                <strong>From Date:</strong> <span id="fromDateSpan" runat="server">N/A</span><br />
                                <strong>To Date:</strong> <span id="toDateSpan" runat="server">N/A</span>
                            </div>

                            
                        </div>
                    </div>

                    <div class="card-body text-center">
                        <h5><strong>SALARY SLIP FOR THE MONTH OF -</strong></h5>
                    </div>

                    <div class="card-body">
                        <div class="table-responsive">
                            <asp:Literal ID="TransportSlip" runat="server"></asp:Literal>
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
            window.location.href = 'Transport.aspx';
        };

        function valid() {
            var fromdate = document.getElementById('<%= fromDate.ClientID %>').value;
            var todate = document.getElementById('<%= toDate.ClientID %>').value;

            if (fromdate === "" || todate === "") {
                swal("Please fill a date to proceed..!", "", "error");
                return false;
            }

            var fromDateObj = new Date(fromdate);
            var toDateObj = new Date(todate);

            if (fromDateObj > toDateObj) {
                swal("From Date cannot be later than To Date!", "", "warning");
                return false;
            }
            return true;
        }
    </script>
</body>
</html>

