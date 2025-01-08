<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fab_Helper_Registration.aspx.cs" Inherits="WebApplication1.Fab_Helper_Registration" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <title>JB-Fabrication - Registration</title>

    <!-- Google Fonts -->
    <link href="https://fonts.gstatic.com" rel="preconnect" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans|Nunito|Poppins" rel="stylesheet" />

    <!-- Vendor CSS Files -->
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />    
    <link href="https://fonts.googleapis.com/css2?family=Saira:wght@400;500;600&display=swap" rel="stylesheet"/>

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

        .login-container {
            display: flex;
            align-items: center;
            justify-content: center;
            flex-direction: column;
        }

        .login-form {
            max-width: 400px;
            padding: 20px;
            background: white;
            border-radius: 8px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.1);
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
            .login-form {
                padding: 30px;
            }
        }

        @media (max-width: 576px) {
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
            <div class="login-container">
                <div class="login-form" id="registerForm">
                    <div class="pt-4 pb-2">
                        <h5 class="text-center pb-0 fs-4" style="color:green;font-family:'saira';">JB-Fab-Registration</h5>

                    </div>

                    <asp:Panel CssClass="needs-validation" runat="server">
                        <div class="form-group">
                            <label for="txtname" class="form-label">Name*</label>
                            <asp:TextBox ID="txtname" CssClass="form-control" runat="server" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="UserContact" class="form-label">Contact No*</label>
                            <asp:TextBox ID="UserContact" CssClass="form-control" runat="server" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="UserPassword" class="form-label">Create Password*</label>
                            <asp:TextBox ID="UserPassword" TextMode="Password" CssClass="form-control" runat="server" required="required"></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label for="txtConPass" class="form-label">Confirm Password*</label>
                            <asp:TextBox ID="txtConPass" TextMode="Password" CssClass="form-control" runat="server" required="required"></asp:TextBox>
                        </div>

                        <asp:Button ID="btnRegister" CssClass="btn btn-primary w-100" runat="server" OnClick="btnRegister_Click" OnClientClick="return valid()" Text="Register" />
                    </asp:Panel>

                    <p class="small mb-0 mt-3 text-center">Already have an account? <a href="Login.aspx" style="color:green;font-family:'saira';">Login</a></p>
                </div>
            </div>
        </div>
    </form>

    <!-- Vendor JS Files -->
    <script src="assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <script>
        function valid() {
            var name = document.getElementById('<%= this.txtname.ClientID %>').value;
            var phone = document.getElementById('<%= this.UserContact.ClientID %>').value;
            var pass = document.getElementById('<%= this.UserPassword.ClientID %>').value;
            var conf = document.getElementById('<%= this.txtConPass.ClientID %>').value;
            mobilecon = /^\d{10}$/;

            if (name == "" || phone == "" || pass == "" || conf == "") {
                swal("Please fill all details to proceed..!", "", "error");
                return false;
            }
            if (phone != '') {
                if (!phone.match(mobilecon)) {
                    swal("Please Enter Valid Contact Number", "", "warning");
                    return false;

                }
            }
           
            if (conf != pass) {

                swal("Please Enter Valid Confirm Password", "", "error");
                return false;

            }

            return true;
        }
    </script>

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
             window.location.href = 'Fab_Helper_Login.aspx';
         };

     </script>


</body>
</html>

