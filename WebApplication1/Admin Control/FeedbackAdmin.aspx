<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Control/AdminDairyFarm.Master" AutoEventWireup="true" CodeBehind="FeedbackAdmin.aspx.cs" Inherits="WebApplication1.Admin_Control.FeedbackAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Saira:wght@400;500;600&display=swap" rel="stylesheet" />
    <!-- Sweet Alert -->
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css" rel="stylesheet" type="text/css" />
    <style>
        body,
        html {
            margin: 0;
            padding: 0;
            font-family: "Saira", sans-serif!important;
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

        .note-card {
            background-color: white;
            border: 1px solid #ddd;
            border-radius: 10px;
            margin: 80px 0;
            padding: 50px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            transition: background-color 0.3s ease;
        }

        .note-card:hover {
            background-color: #f1f1f1;
        }

        .note-title,
        .note-contact,
        .note-body {
            display: flex;
            align-items: center;
            font-size: 18px;
            margin-bottom: 15px;
        }

        .note-title img,
        .note-contact img,
        .note-body img {
            width: 24px;
            height: 24px;
            margin-right: 10px;
            margin-bottom:10px;
        }

        .note-body {
            font-size: 16px;
            display: none;
            margin-top: 10px;
        }

        .note-time {
            font-size: 14px;
            color: gray;
            margin-top: 8px;
        }

        .delete-btn {
            display: none;
            background-color: #dc3545;
            color: white;
            border: none;
            padding: 8px 12px;
            cursor: pointer;
            border-radius: 5px;
            transition: background-color 0.3s;
            width: 100px;
            margin-top: 10px;
        }

        .delete-btn:hover {
            background-color: darkred;
        }

        .footer {
            position: fixed;
            bottom: 0;
            left: 0;
            right: 0;
            background-color: white;
            padding: 10px;
            display: flex;
            justify-content: center;
            align-items: center;
            box-shadow: 0 -2px 5px rgba(0, 0, 0, 0.1);
        }

        .new-note-btn {
            background-color: #007bff;
            color: white;
            border-radius: 50%;
            width: 60px;
            height: 60px;
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 24px;
            text-decoration: none;
        }

        @media (max-width: 768px) {
            .note-card {
                font-size: 14px;
            }

            .delete-btn {
                font-size: 14px;
            }
        }

        .note-card a {
            color: black;
            text-decoration: none;
        }

        .note-card a:hover {
            color: #555;
            text-decoration: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pagetitle">
        <h1>User Feedback</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item active">User Feedback</li>
            </ol>
        </nav>
    </div>

    <section class="section">
        <div class="row">
            <div class="container mt-4" style="margin-bottom: 100px;">

                <asp:Repeater runat="server" ID="NoteRep">
                    <ItemTemplate>
                        <div class="note-card" onclick="toggleNoteContent(this)">
                            <div>
                                <div class="note-title">
                                    <img src="../assets/img/username.png" alt="User Icon" />
                                    <a class="note-title" href='#'><%# Eval("user_name") %></a>
                                </div>
                                <div class="note-contact">
                                    <img src="../assets/img/usercontact.png" alt="Contact Icon" />
                                    <a class="note-contact" href='#'><%# Eval("user_contact") %></a>
                                </div>
                                <div class="note-body">
                                    <img src="../assets/img/userfeedback.png" alt="Feedback Icon" />
                                    <a href='#'><%# Eval("feedback") %></a>
                                </div>
                                <div class="note-time">
                                    <a href='#'><%# Eval("date", "{0:dd-MMM-yyyy hh:mm tt}") %></a>
                                </div>
                            </div>

                            <asp:LinkButton runat="server" ID="btn_Delete" Text="Delete" CssClass="delete-btn" 
                                OnClientClick="return confirm('Do you want to delete this Item?')" 
                                OnClick="btn_Delete_Click" Style="color: white;">
                            </asp:LinkButton>
                        </div>

                        <asp:Label runat="server" ID="DelRep" Style="display: none" Text='<%# Eval("feedback_id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        </div>

        <script>
            function toggleNoteContent(noteCard) {
                const noteBody = noteCard.querySelector('.note-body');
                const deleteButton = noteCard.querySelector('.delete-btn');

                // Toggle visibility of the note body
                if (noteBody.style.display === 'block') {
                    noteBody.style.display = 'none';  // Hide note body
                } else {
                    noteBody.style.display = 'block';  // Show note body
                }

                // Toggle visibility of the delete button
                if (deleteButton.style.display === 'block') {
                    deleteButton.style.display = 'none';  // Hide delete button
                } else {
                    deleteButton.style.display = 'block';  // Show delete button
                }
            }

        </script>

    </section>
</asp:Content>
