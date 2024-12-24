<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fa_Admin_DatePE.aspx.cs" Inherits="WebApplication1.DatePE" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Date To Date Profit Expense Management</title>

    <!-- Vendor CSS Files -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/vendor/bootstrap-icons/bootstrap-icons.css" />
    <link href="https://fonts.googleapis.com/css2?family=Saira:wght@400;500;600&display=swap" rel="stylesheet" />



    <!-- Sweet Alert -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />



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
            padding: 10px 20px;
            background-color: #f8f9fa;
            border-bottom: 1px solid #ddd;
            margin-bottom: 20px;
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            z-index: 1000;
            width: 100%;
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
            padding: 20px;
        }


        .month-box {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 20px;
            border: 1px solid #10a37f;
            border-radius: 6px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
            background-color: #fff;
            transform: scale(0.5) translateY(-50px);
            opacity: 0;
            transition: transform 0.6s ease, opacity 0.6s ease;
        }


            .month-box.active {
                transform: scale(1) translateY(0);
                opacity: 1;
            }

        .profit-expense {
            font-size: 1.2rem;
            color: #495057;
            text-align: right;
        }

            .profit-expense .profit,
            .profit-expense .expense {
                margin: 0;
            }

            .profit-expense .profit {
                color: green;
            }

            .profit-expense .expense {
                color: red;
            }

        .form-group {
            position: relative;
            margin-bottom: 15px;
            padding-left: 15px;
        }

        .form-label {
            position: absolute;
            top: -8px;
            left: 15px;
            background: white;
            padding: 0 5px;
            font-size: 0.9rem;
            color: #495057;
            margin-top: 20px;
        }

        .form-control {
            appearance: none;
            background-color: #fff;
            border: 1px solid #10a37f;
            border-radius: 6px;
            box-sizing: border-box;
            color: #2d333a;
            font-family: inherit;
            font-size: 16px;
            height: 52px;
            line-height: 1.1;
            outline: none;
            padding-block: 1px;
            padding-inline: 2px;
            padding: 0 16px;
            transition: box-shadow .2s ease-in-out, border-color .2s ease-in-out;
            width: 100%;
            text-rendering: auto;
            letter-spacing: normal;
            word-spacing: normal;
            text-transform: none;
            text-indent: 0;
            text-shadow: none;
            display: inline-block;
            text-align: start;
            margin: 0;
            margin-top: 20px;
        }

            .form-control:focus {
                border-color: black;
                box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
                outline: none;
            }

            .form-control[data-filled="true"] {
                border-color: green;
            }


        .btn-submit {
            display: flex;
            align-items: center;
            justify-content: center;
            position: relative;
            height: 52px;
            width: 100%;
            background-color: #10a37f;
            color: #fff;
            margin: 54px 0 0;
            border-radius: 6px;
            padding: 4px 16px;
            font: inherit;
            border-width: 0;
            cursor: pointer;
        }

            .btn-submit:hover {
                background-color: #0056b3;
            }

        @media (max-width: 767.98px) {
            .form-control {
                margin-bottom: 30px;
            }

            .form-group.row {
                flex-direction: column;
            }
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid" style="margin-top: 200px;">
            <!-- Page Header with Image and Title -->
            <div class="header">
                <img src="assets/img/calendar_16118660.png" alt="Feed Icon" />
                <h1>Date To Date Profit Expense Management</h1>
            </div>

            <div class="content">

                <div class="row justify-content-center">
                    <div class="col-md-8 col-lg-6">
                        <div class="form-group row">
                            <div class="col-12 col-md-6">
                                <label for="fromDate" class="form-label">From Date*</label>
                                <asp:TextBox ID="fromDate" CssClass="form-control" runat="server" Style="margin-left: -10px;" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-12 col-md-6">
                                <label for="toDate" class="form-label">To Date*</label>
                                <asp:TextBox ID="toDate" CssClass="form-control" runat="server" Style="margin-left: -10px;" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>


                        <div class="form-group row justify-content-center" style="padding-left: 0px;">
                            <div class="col-6">
                                <asp:Button ID="btnSearchDatePE" OnClick="btnSearchDatePE_Click" OnClientClick="return valid()" Text="Search" CssClass="btn btn-submit btn-block" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid" style="margin-top: 70px;">
            <asp:Literal runat="server" ID="DatePEResult" />
        </div>
    </form>




    <script>
        function valid() {
            var fromdate = document.getElementById('<%= this.fromDate.ClientID %>').value;
            var todate = document.getElementById('<%= this.toDate.ClientID %>').value;


            if (fromdate == "" || todate == "") {
                swal("Please fill all details to proceed..!", "", "error");
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



    <script type="text/javascript">

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
            window.location.href = 'WebPage.aspx';
        };
    </script>


</body>
</html>
