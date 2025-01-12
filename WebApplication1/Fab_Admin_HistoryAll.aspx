<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fab_Admin_HistoryAll.aspx.cs" Inherits="WebApplication1.Fab_Admin_HistoryAll" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>History</title>

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


        .card-horizontal {
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 10px;
            background-color: #fff;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            margin-bottom: 20px;
            flex-wrap: nowrap;
            opacity: 0;
            transform: scale(0);
            transition: transform 0.6s ease, opacity 0.6s ease;
        }


            .card-horizontal.active {
                transform: scale(1);
                opacity: 1;
            }

        .left-content {
            display: flex;
            align-items: center;
        }

            .left-content img {
                height: 50px;
                margin-right: 15px;
            }

            .left-content .text-content {
                display: flex;
                flex-direction: column;
            }

                .left-content .text-content h5 {
                    margin: 0;
                    color: #495057;
                    font-weight: bold;
                }

                .left-content .text-content p {
                    margin: 0;
                    color: #777;
                }

        .right-content {
            text-align: center;
            white-space: nowrap;
        }

            .right-content h4 {
                font-size: 1.5rem;
                margin: 0;
                color: green;
            }

        .month-year-header {
            text-align: center;
            margin: 50px 0;
            background-color: #f0f0f0;
            padding: 20px;
            border-radius: 15px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
            opacity: 0;
            transform: scale(0);
            transition: transform 0.6s ease, opacity 0.6s ease;
        }


            .month-year-header.active {
                opacity: 1;
                transform: scale(1);
            }

            .month-year-header h3 {
                margin: 0;
                font-size: 18px;
                color: #333;
            }


        @media (max-width: 768px) {
            .card-horizontal {
                justify-content: space-between;
                flex-wrap: nowrap;
            }

            .left-content {
                justify-content: flex-start;
                flex-direction: row;
                text-align: left;
            }

            .right-content {
                text-align: right;
            }
        }

        @media (max-width: 576px) {
            .card-horizontal {
                flex-direction: row;
                align-items: flex-start;
            }

            .left-content {
                flex-direction: row;
                justify-content: flex-start;
            }

                .left-content img {
                    height: 40px;
                    margin-right: 10px;
                }

                .left-content .text-content h5 {
                    font-size: 1.2rem;
                }

            .right-content h4 {
                font-size: 1.2rem;
            }
        }

        .search-bar-container {
            width: 100%;
            max-width: 600px;
            margin: 100px auto 20px;
            text-align: center;
        }

        .search-bar {
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            font-size: 16px;
            width: 100%;
        }

            .search-bar:focus {
                outline: none;
                border-color: #007bff;
                box-shadow: 0 0 5px rgba(0, 123, 255, 0.5);
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <!-- Page Header with Image and Feeds Title -->
            <div class="header">
                <img src="assets/img/HistoryRecord.png" alt="Feed Icon" />
                <h1>History</h1>
            </div>

            <div class="search-bar-container">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text" id="searchIcon">
                            <i class="bi bi-search"></i>
                        </span>
                    </div>
                    <input
                        type="text"
                        id="searchInput"
                        class="form-control search-bar"
                        placeholder="Search..."
                        oninput="filterRecords()"
                        aria-describedby="searchIcon" />
                </div>
            </div>




            <div style="margin-top: 10px"></div>


            <asp:Literal ID="litRecords" runat="server"></asp:Literal>


        </div>
    </form>

    <script type="text/javascript">
        function filterRecords() {
            const input = document.getElementById("searchInput").value.toLowerCase();
            const records = document.querySelectorAll(".card-horizontal, .month-year-header");

            records.forEach(record => {
                const textContent = record.textContent || record.innerText;

                if (textContent.toLowerCase().includes(input)) {
                    record.style.display = "";
                } else {
                    record.style.display = "none";
                }
            });
        }
    </script>


    <script type="text/javascript">

        function animateElements() {
            const monthYearHeaders = document.querySelectorAll('.month-year-header');
            const cardHorizontals = document.querySelectorAll('.card-horizontal');


            monthYearHeaders.forEach((header, index) => {
                setTimeout(() => {
                    header.classList.add('active');
                }, index * 200);
            });


            cardHorizontals.forEach((card, index) => {

                setTimeout(() => {
                    card.classList.add('active');
                }, (index + monthYearHeaders.length) * 100);
            });
        }


        window.onload = function () {

            if (history.state === null) {
                history.pushState({}, 'History', window.location.href);
            }

            const img = document.querySelector('.header img');
            const h1 = document.querySelector('.header h1');


            img.style.transition = 'transform 0.8s ease-in-out';
            h1.style.transition = 'transform 0.8s ease-in-out 0.2s';


            img.style.transform = 'translateX(0)';
            h1.style.transform = 'translateX(0)';


            animateElements();
        };


        window.onpopstate = function (event) {
            window.location.href = 'Fabrication_Admin.aspx';
        };


        window.addEventListener('DOMContentLoaded', function () {
            const img = document.querySelector('.header img');
            const h1 = document.querySelector('.header h1');


            img.style.transform = 'translateX(100%)';
            h1.style.transform = 'translateX(100%)';
        });
    </script>



    <!-- Bootstrap JS Files -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>

