<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fa_Helper_Att.aspx.cs" Inherits="WebApplication1.OtherFeed" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Helper Attendance Management</title>

    <!-- Vendor CSS Files -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
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
        }

        .header {
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            display: flex;
            justify-content: flex-start;
            align-items: center;
            padding: 10px 20px;
            background-color: #f8f9fa;
            border-bottom: 1px solid #ddd;
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
            padding: 110px 20px;
        }

        .date-label {
            position: absolute;
            top: 10px;
            right: 10px;
            text-align: right;            
                margin-top: 100px;
        }

        .day-label {
            display: block;
            margin-top: 5px;
        }

        .btn-full-day {
            background-color: green;
            color: white;
            border-radius: 8px;
        }

        .btn-half-day {
            background-color: yellow;
            color: black;
            border-radius: 8px;
        }

        .btn-off-day {
            background-color: red;
            color: white;
            border-radius: 8px;
        }

        @media (max-width: 768px) {
            .header h1 {
                font-size: 20px;
            }

            .buttons-container .btn {
                width: 100%; /* Full-width buttons on smaller screens */
            }

            .date-label {
                font-size: 14px;
            }
        }

        .buttons-container {
            display: flex;
            flex-direction: column;
            align-items: center;
            gap: 15px;
        }

        .buttons-container .btn {
            width: 200px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
            <!-- Fixed Header -->
            <div class="header">
                <img src="FabImage/immigration_3125856.png" alt="Feed Icon" />
                <h1>Helper Attendance Management</h1>
            </div>

            <!-- Content Section -->
            <div class="content">
                <div class="container">
                    <!-- Date and Day Labels -->
                    <div class="date-label">
                        <asp:Label ID="lblDate" runat="server"></asp:Label>
                        <asp:Label ID="lblDay" runat="server" CssClass="day-label"></asp:Label>
                    </div>

                    <!-- Buttons Section -->
                    <div class="row justify-content-center align-items-center" style="min-height: 70vh;">
                        <div class="col-md-4 col-sm-8 col-10">
                            <div class="buttons-container">
                                <asp:Button ID="btnFullDay" runat="server" Text="Full Day" CssClass="btn btn-full-day" />
                                <asp:Button ID="btnHalfDay" runat="server" Text="Half Day" CssClass="btn btn-half-day" />
                                <asp:Button ID="btnOffDay" runat="server" Text="Off Day" CssClass="btn btn-off-day" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Script Links -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>
</body>
</html>
