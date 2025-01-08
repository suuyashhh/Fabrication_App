<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fab_Helper_Login.aspx.cs" Inherits="WebApplication1.Fab_Helper_Login" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <title>Suyash Patil Dairy Farm</title>

    <!-- Google Fonts -->
    <link href="https://fonts.gstatic.com" rel="preconnect" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans|Nunito|Poppins" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Saira:wght@400;500;600&display=swap" rel="stylesheet" />

    <!-- Vendor CSS Files -->
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />

    <!-- Template Main CSS File -->
    <link href="assets/css/style.css" rel="stylesheet" />

    <!-- Sweet Alert -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />

    <!-- Custom CSS -->
    <style>
        * {
            font-family: "Saira", sans-serif;
        }

        body, html {
            height: 100%;
            margin: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            background-color: #f8f9fa;
        }

        .container {
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
            position: relative;
        }

        .logo-container {
            display: flex;
            justify-content: center;
            align-items: center;
            flex-direction: column;
            position: absolute;
            transition: transform 2s ease-in-out;
        }

            .logo-container.move-up {
                bottom: 50%;
                transform: translateY(-50%);
                transition: bottom 1s ease-in-out, transform 1s ease-in-out 3s;
            }

            .logo-container.move-up-top {
                bottom: 100%;
                transform: translateY(-100%);
                opacity: 0;
                transition: bottom 1s ease-in-out, opacity 1s ease-in-out;
            }



        .logo img {
            max-height: 180px;
        }

        .logo-text {
            margin-top: 10px;
            font-size: 24px;
            font-weight: bold;
            text-align: center;
        }

        .login-container {
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }

        .login-form {
            display: none;
            max-width: 400px;
            padding: 20px;
            background: white;
            border-radius: 8px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
            opacity: 0;
            transition: opacity 1s ease-in-out;
        }

            .login-form.show {
                display: block;
                opacity: 1;
            }

        .form-label {
            position: absolute;
            top: -8px;
            left: 15px;
            background: white;
            padding: 0 5px;
            font-size: 0.9rem;
            color: #495057;
        }

        .form-group {
            position: relative;
            margin-bottom: 15px;
        }

        .form-control {
            appearance: none;
            background-color: #fff;
            border: 1px solid #10a37f;
            border-radius: 6px;
            padding: 12px;
            width: 100%;
            font-size: 16px;
            color: #2d333a;
            margin-top: 20px;
            transition: border-color 0.3s, box-shadow 0.3s;
        }

            .form-control:focus {
                border-color: green;
            }

            .form-control.green-border {
                border-color: green !important;
            }


        .form-control {
            box-shadow: 0px 4px 8px rgba(0, 0, 0, 0.1);
        }

        @media (min-width: 992px) {
            .logo img {
                max-height: 320px;
                margin-top: 150px;
            }

            .login-form {
                padding: 30px;
            }

            .logo-text {
                font-size: 28px;
            }
        }

        @media (max-width: 576px) {
            .logo-container.move-up {
                transform: translateY(-10%);
            }

            .login-form {
                padding: 15px;
                max-width: 99%;
            }
        }
    </style>
</head>

<body>
    <form runat="server">
        <div class="container">
            <div class="logo-container" id="logoContainer">
                <div class="logo">
                    <img src="assets/img/Cowner.png" alt="Your Logo" />
                </div>
                <div class="logo-text">Suyash's DairyFarm<span style="color: green;">Recordes</span> Webapp</div>
            </div>

            <div class="login-container">
                <div class="login-form" id="loginForm">
                    <div class="pt-4 pb-2">
                        <h5 class="text-center pb-0 fs-4" style="color: green; font-family: 'saira';">Fab Emp Login</h5>
                        <p class="text-center small">Enter your username & password to login</p>
                    </div>

                    <asp:Panel CssClass="needs-validation" runat="server">
                        <div class="form-group">
                            <label for="UserContact" class="form-label">UserContact*</label>
                            <asp:TextBox ID="UserContact" CssClass="form-control" runat="server" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="UserPassword" class="form-label">Password*</label>
                            <asp:TextBox ID="UserPassword" TextMode="Password" CssClass="form-control" runat="server" required="required"></asp:TextBox>
                        </div>

                        <div class="form-check mb-3">
                            <asp:CheckBox ID="rememberMe" CssClass="form-check-input" runat="server" />
                            <label class="form-check-label" for="rememberMe">Remember me</label>
                        </div>

                        <asp:Button ID="btnLogin" CssClass="btn btn-primary w-100" runat="server" Text="Login"  />
                    </asp:Panel>

                    <p class="small mb-0 mt-3 text-center">Don't have an account? <a href="Registration.aspx" style="color: green; font-family: 'saira';">Create an account</a></p>
                </div>
            </div>
        </div>
    </form>

    <!-- Vendor JS Files -->
    <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Custom JS -->
    <script>
        setTimeout(function () {
            const logoContainer = document.getElementById('logoContainer');
            logoContainer.classList.add('move-up');
            setTimeout(function () {
                logoContainer.classList.add('move-up-top');
                document.getElementById('loginForm').classList.add('show');
            }, 0);
        }, 2000);

    </script>

    <script>
        document.querySelectorAll('.form-control').forEach(function (input) {
            input.addEventListener('focus', function () {
                this.classList.add('green-border');
            });
        });
    </script>

    <script type="text/javascript">

        window.onpopstate = function (event) {
            window.location.href = 'Fab_Helper_Login.aspx';
        };

        window.onload = function () {
            if (history.state === null) {
                history.pushState({}, 'Fab_Helper_Login', window.location.href);
            }
        };
    </script>


</body>
</html>

