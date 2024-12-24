<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="WebApplication1.Admin_Control.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />

    <title>Admin Control</title>
    <meta content="" name="description" />
    <meta content="" name="keywords" />

    <!-- Favicons -->
    <link href="../assets/img/logom.png" rel="icon" />
    <link href="../assets/img/logom.png" rel="apple-touch-icon" />

    <!-- Google Fonts -->
    <link href="https://fonts.gstatic.com" rel="preconnect" />
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,300i,400,400i,600,600i,700,700i|Nunito:300,300i,400,400i,600,600i,700,700i|Poppins:300,300i,400,400i,500,500i,600,600i,700,700i" rel="stylesheet" />

    <!-- Vendor CSS Files -->
    <link href="../assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />
    <link href="../assets/vendor/boxicons/css/boxicons.min.css" rel="stylesheet" />
    <link href="../assets/vendor/quill/quill.snow.css" rel="stylesheet" />
    <link href="../assets/vendor/quill/quill.bubble.css" rel="stylesheet" />
    <link href="../assets/vendor/remixicon/remixicon.css" rel="stylesheet" />
    <link href="../assets/vendor/simple-datatables/style.css" rel="stylesheet" />



    <!-- Template Main CSS File -->
    <link href="../assets/css/style.css" rel="stylesheet" />
    <%-- <style>
    .sidebar-nav .nav-link:hover, .sidebar-nav .nav-link:focus {
        color: #ed3237;
    }

    .sidebar-nav .nav-link i:hover, .sidebar-nav .nav-link i:focus {
        color: #ed3237;
    }
</style>--%>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />

    <style>
        body{
            font-family: "Saira", sans-serif;
            background-color: #434c50;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="container">

                <section class="section register min-vh-100 d-flex flex-column align-items-center justify-content-center py-4">
                    <div class="container">
                        <div class="row justify-content-center">
                            <div class="col-lg-4 col-md-6 d-flex flex-column align-items-center justify-content-center">

                                <div class="d-flex justify-content-center py-4">
                                    <h1 class="text-white fw-bold d-block">DairyFarm<span class="text-secondary">Recordes</span> </h1>
                                </div>
                                <!-- End Logo -->

                                <div class="card yashh mb-3">

                                    <div class="card-body">

                                        <div>
                                            <h1 class=" text-center" style="color: black;margin:30px 0px">Admin Login</h1>
                                        </div>

                                        <div class="row g-3 needs-validation" novalidate="">

                                            <div class="col-12">
                                                <div class="input-box">
                                                    <asp:TextBox runat="server" ID="txtcontact" placeholder="Admin_id." CssClass="form-control"></asp:TextBox>
                                                    
                                                </div>
                                            </div>

                                            <div class="col-12">
                                                <div class="input-box">
                                                    <asp:TextBox runat="server" ID="txtpass" placeholder="Password" CssClass="form-control"></asp:TextBox>
                                                    
                                                </div>
                                            </div>

                                            <div class="col-12" style="margin-bottom: 20px;">
                                                <asp:Button runat="server" OnClientClick="return valid()" OnClick="btnbutton_Click" ID="btnbutton" class="btn"  CssClass="btn btn-success w-100" Text="Login" />
                                            </div>

                                        </div>

                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>

                </section>

            </div>


            <script>
                function valid() {
                    var phone = document.getElementById('<%= this.txtcontact.ClientID %>').value;
    var pass = document.getElementById('<%= this.txtpass.ClientID %>').value;


                    if (phone == "" || pass == "" || ) {
                        swal("Please fill Login details..!", "", "error");
                        return false;
                    }

                    return true;
                }
            </script>


        </div>
    </form>
</body>
</html>

