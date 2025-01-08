<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fab_Admin_Master.aspx.cs" Inherits="WebApplication1.Fab_Admin_Master" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <title>Helper & Advanse Money Master</title>

    <!-- Vendor CSS Files -->
    <link href="assets/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/vendor/bootstrap-icons/bootstrap-icons.css" rel="stylesheet" />

    <!-- Sweet Alert -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
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
            position: fixed;
            top: 0;
            left: 0;
            right: 0;
            z-index: 1000;
        }

            .header img {
                height: 40px;
                margin-right: 10px;
            }

            .header h1 {
                font-size: 24px;
                margin: 0;
                color: #495057;
            }

        .content {
            padding: 100px 20px 50px;
        }

        .form-group {
            position: relative;
            margin-bottom: 15px;
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
            margin: 24px 0 0;
            border-radius: 6px;
            padding: 4px 16px;
            font: inherit;
            border-width: 0;
            cursor: pointer;
            margin-top: 50px;
        }

            .btn-submit:hover {
                background-color: #0056b3;
            }

        .grid-view {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header -->
        <div class="header">
            <img src="FabImage/AdminMaster.png" alt="Animal Icon" />
            <h1>Helper & Fab Master</h1>
        </div>

        <!-- Main Content -->
        <div class="content container-fluid">
            <div class="row">
                <!-- Advance Money Section -->
                <div class="col-md-6 col-sm-12 mb-4">
                    <h2>Advance Money</h2>
                    <div class="form-group">
                        <label class="form-label">Helper Name*</label>
                        <asp:DropDownList ID="ddlHelpername" runat="server" CssClass="form-control form-control-lg" DataTextField="User_name" DataValueField="User_name"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Advance Money*</label>
                        <asp:TextBox ID="AdvanceMoney" CssClass="form-control" runat="server" TextMode="Number" onkeyup="checkInput(this)"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnSubmitAdvance" Text="Submit" OnClick="btnSubmitAdvance_Click" OnClientClick="return validF()" CssClass="btn-submit" runat="server" />
                </div>

                <!-- Grid View Section -->
                <div class="col-md-6 col-sm-12 grid-view mb-4">
                    <h2>Manage Advance Money</h2>
                    <div class="table-responsive">
                        <asp:GridView runat="server" ID="gridAdvance" DataKeyNames="Exp_id" AutoGenerateColumns="false" OnRowEditing="gridAdvance_RowEditing" OnRowCancelingEdit="gridAdvance_RowCancelingEdit" OnRowUpdating="gridAdvance_RowUpdating" OnRowDeleting="gridAdvance_RowDeleting" CssClass="table table-striped table-bordered " Style="border: 1px solid #10a37f; border-radius: 6px; margin-top: 20px">
                            <Columns>
                                <asp:TemplateField HeaderText="Date:">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblDate" Text='<%# Convert.ToDateTime(Eval("ExpenseDate")).ToString("dd-MMM-yyyy") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtDate" Text='<%# Convert.ToDateTime(Eval("ExpenseDate")).ToString("dd-MMM-yyyy") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name:">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblname" Text='<%# Eval("User_name") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Advance Money:">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblname" Text='<%# Eval("User_advance") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtAdv" Text='<%# Eval("User_advance") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>


                                <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>

                <!-- Helper Grid Section -->
                <div class="col-12 grid-view">
                    <h2>Manage Helper</h2>
                    <div class="table-responsive">
                        <asp:GridView runat="server" ID="gridHelper" DataKeyNames="User_id" AutoGenerateColumns="false" OnRowEditing="gridHelper_RowEditing" OnRowCancelingEdit="gridHelper_RowCancelingEdit" OnRowUpdating="gridHelper_RowUpdating" OnRowDeleting="gridHelper_RowDeleting" CssClass="table table-striped table-bordered " Style="border: 1px solid #10a37f; border-radius: 6px;">
                            <Columns>
                                <asp:TemplateField HeaderText="Name:">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblname" Text='<%# Eval("User_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtname" Text='<%# Eval("User_name") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact:">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblContact" Text='<%# Eval("User_contact") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtContact" Text='<%# Eval("User_contact") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Password:">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblpass" Text='<%# Eval("User_pass") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtpass" Text='<%# Eval("User_pass") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Salary:">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblsalary" Text='<%# Eval("User_salary") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox runat="server" ID="txtsalary" Text='<%# Eval("User_salary") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script>
        function checkInput(input) {
            if (input.value.trim() !== '') {
                input.setAttribute('data-filled', 'true');
            } else {
                input.removeAttribute('data-filled');
            }
        }
    </script>





    <script>
        function validF() {
            var name = document.getElementById('<%= this.AdvanceMoney.ClientID %>').value;
            var money = document.getElementById('<%= this.ddlHelpername.ClientID %>').value;


            if (name == "" || money == "") {
                swal("Please fill all details to proceed..!", "", "error");
                return false;
            }


            return true;
        }
    </script>


    <script type="text/javascript">
        window.onpopstate = function (event) {
            window.location.href = 'Fabrication_Admin.aspx';
        };

        window.onload = function () {
            if (history.state === null) {
                history.pushState({}, 'Animal', window.location.href);
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
