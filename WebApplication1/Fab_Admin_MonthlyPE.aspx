<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fab_Admin_MonthlyPE.aspx.cs" Inherits="WebApplication1.Fab_Admin_MonthlyPE" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Monthly Profit Expense Management</title>

    <!-- Vendor CSS Files -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="assets/vendor/bootstrap-icons/bootstrap-icons.css" />
    <link href="https://fonts.googleapis.com/css2?family=Saira:wght@400;500;600&display=swap" rel="stylesheet" />


    <!-- Custom CSS -->
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
            padding: 5px;
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

            .month-box h2 {
                font-weight: bold;
                margin: 0;
                color: #007bff;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <!-- Page Header with Image and Feeds Title -->
            <div class="header">
                <img src="assets/img/fiscal_13495984.png" alt="Feed Icon" />
                <h1>Monthly Profit Expense Management</h1>
            </div>

            <div style="margin-top: 150px"></div>
            <!-- Content -->
            <asp:Literal runat="server" ID="MonthPE"></asp:Literal>

        </div>
    </form>



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


    <!-- Bootstrap JS Files -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>

