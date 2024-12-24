<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fa_Helper_WebPage.aspx.cs" Inherits="WebApplication1.WebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Farm Records</title>
    <!-- Bootstrap CSS -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <link href="https://fonts.googleapis.com/css2?family=Saira:wght@400;500;600&display=swap" rel="stylesheet" />


    <style>
        body {
            font-family: "Saira", sans-serif;
        }

        .navbar-custom {
            position: fixed;
            top: 30px;
            left: 30px;
            right: 30px;
            width: auto;
            background-color: #343a40;
            border-radius: 15px;
            z-index: 1000;
        }

        .navbar-brand {
            margin-left: 20px;
            color: #ffffff;
            font-weight: bold;
        }

        .navbar-toggler {
            margin-right: 20px;
        }


        .footer {
            position: fixed;
            bottom: 0;
            left: 0;
            width: 100%;
            background-color: #343a40;
            color: #ffffff;
            text-align: center;
            padding: 10px 0;
        }


        .content-container {
            margin-top: 8rem;
            margin-bottom: 3rem;
            padding-bottom: 80px;
        }

        .row-spacing {
            margin-bottom: 20px;
        }

        .box {
            background-color: #f8f9fa;
            padding: 8px; 
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            text-align: center;
            border-radius: 6px;
            transition: transform 0.2s; 
        }

            .box img {
                max-width: 50px; 
                margin-bottom: 8px;
            }

            .box h5 {
                margin: 0;
                font-weight: bold;
                color: #343a40;
                font-size: 12px; 
            }

            .box:hover {
                transform: scale(1.05); 
            }

        @media (max-width: 768px) {
            .col-4 {
                max-width: 50%; 
            }
        }


        @media screen and (max-width: 1000px) {
            #logoutButton {
                margin-left: 15px;
            }
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">

        <nav class="navbar navbar-expand-lg navbar-dark navbar-custom">

            <asp:Label runat="server" class="navbar-brand" ID="btn_lbl"></asp:Label>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav mr-auto"></ul>
                <asp:Button ID="logoutButton" runat="server" Text="Logout" OnClick="logoutButton_Click1" CssClass="btn btn-primary my-2 my-sm-0" />



            </div>
        </nav>

        <!-- Content -->
        <div class="container content-container">
            <!-- First row -->
            <div class="row row-spacing">
                <div class="col-4">
                    <div class="box" onclick="window.location.href='Fab_Helper_Att.aspx';" style="cursor: pointer;">
                        <img src="FabImage/Attendense.png" alt="Image 1" />
                        <h5>Attendance</h5>
                    </div>
                </div>
                <div class="col-4">
                    <div class="box" onclick="window.location.href='Fab_Helper_Month_Atten.aspx';" style="cursor: pointer;">
                        <img src="FabImage/MonthAttendanse.png" alt="Image 2" />
                        <h5>Monthly Attendance</h5>
                    </div>
                </div>
                <div class="col-4">
                    <div class="box" onclick="window.location.href='Fab_Admin_.aspx';" style="cursor: pointer;">
                        <img src="FabImage/Expanse.png" alt="Image 3" />
                        <h5>Good Expanse</h5>
                    </div>
                </div>
            </div>

            <!-- Second row -->
            <div class="row row-spacing">
                <div class="col-4">
                    <div class="box" onclick="window.location.href='Fab_Helper_SalaryBill.aspx';" style="cursor: pointer;">
                        <img src="FabImage/MonthSalery.png" alt="Image 1" />
                        <h5>Salary Bill</h5>
                    </div>
                </div>
                <div class="col-4">
                    <div class="box" onclick="window.location.href='Bill.aspx';" style="cursor: pointer;">
                        <img src="assets/img/bill_1052856.png" alt="Image 2" />
                        <h5>Received Bill</h5>
                    </div>
                </div>
                <div class="col-4">
                    <div class="box" onclick="window.location.href='OtherFeed.aspx';" style="cursor: pointer;">
                        <img src="assets/img/Dryfeed_9137270.png" alt="Image 3" />
                        <h5>Other Feed</h5>
                    </div>
                </div>
            </div>

           


        </div>

        <!-- Footer -->
        <footer class="footer">
            Developed by <a href="About.aspx" style="color: white!important">@SuyashPatil</a>
        </footer>
    </form>

    <!-- Bootstrap JS and dependencies -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.1/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <script type="text/javascript">

        window.onpopstate = function (event) {
            window.location.href = 'WebPage.aspx';
        };

        window.onload = function () {
            if (history.state === null) {
                history.pushState({}, 'WebPage', window.location.href);
            }
        };
    </script>


</body>
</html>
