<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fa_Helper_SalaryBill.aspx.cs" Inherits="WebApplication1.Feedss" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Salary Bill</title>

    <!-- Vendor CSS Files -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/vendor/bootstrap-icons/bootstrap-icons.css" />
    <link href="https://fonts.googleapis.com/css2?family=Saira:wght@400;500;600&display=swap" rel="stylesheet" />


    <!-- Sweet Alert -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />


    <!-- Custom CSS -->
    <style>
        body, html {
            margin: 0;
            padding: 0;
            font-family: "Saira", sans-serif;
            height: 100%;
        }

        .header {
            display: flex;
            justify-content: flex-start;
            align-items: center;
            padding: 10px 20px;
            background-color: #f8f9fa;
            border-bottom: 1px solid #ddd;
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
            padding: 100px 20px 20px;
            display: flex;
            justify-content: center;
            align-items: center;
            height: calc(100vh - 100px);
        }
          .month-card {
            width: 300px;
            height: 200px;
            display: flex;
            justify-content: center;
            align-items: center;
            background: linear-gradient(145deg, #ffffff, #e6e6e6);
            box-shadow: 3px 3px 8px #d1d1d1, -3px -3px 8px #ffffff;
            border-radius: 15px;
        }

        .month-card h1 {
            font-size: 32px;
            font-weight: bold;
            color: #495057;
            text-transform: uppercase;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">

            <!-- Header with fixed position -->
            <div class="header">
                <img src="FabImage/payment_10826416.png" alt="Feed Icon" />
                <h1>Salary Bill</h1>
            </div>


            <div class="content">
                <div class="month-card">
                    <h1>November</h1>
                </div>
            </div>
        </div>
    </form>




    <!-- Back button handling script -->
    <script type="text/javascript">
        window.onpopstate = function (event) {
            window.location.href = 'WebPage.aspx';
        };

        window.onload = function () {
            if (history.state === null) {
                history.pushState({}, 'Feeds', window.location.href);
            }

            const img = document.querySelector('.header img');
            const h1 = document.querySelector('.header h1');

            img.style.transition = 'transform 1s ease-in-out';
            h1.style.transition = 'transform 1s ease-in-out 0.2s';

            img.style.transform = 'translateX(0)';
            h1.style.transform = 'translateX(0)';
        };

        window.addEventListener('DOMContentLoaded', function () {
            const img = document.querySelector('.header img');
            const h1 = document.querySelector('.header h1');

            img.style.transform = 'translateX(100%)';
            h1.style.transform = 'translateX(100%)';
        });
    </script>

</body>
</html>
