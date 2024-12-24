<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Control/AdminDairyFarm.Master" AutoEventWireup="true" CodeBehind="Registrations.aspx.cs" Inherits="WebApplication1.Admin_Control.Registrations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body,
        html {
            margin: 0;
            padding: 0;
            font-family: "Saira", sans-serif!important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="pagetitle">
        <h1>Registrations</h1>
        <nav>
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="index.html">Home</a></li>
                <li class="breadcrumb-item active">Registations</li>
            </ol>
        </nav>
    </div>


    <section class="section">
        <div class="row" style="margin-top: 80px;">
            <div class="col-lg-12">

                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Registered</h5>


                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="gridv" DataKeyNames="user_id" AutoGenerateColumns="false" OnRowEditing="gridv_RowEditing" OnRowCancelingEdit="gridv_RowCancelingEdit" OnRowUpdating="gridv_RowUpdating" OnRowDeleting="gridv_RowDeleting" CssClass="table " Style="text-align: center; margin-top: 90px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Name:">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblname" Text='<%# Eval("user_name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txtname" Text='<%# Eval("user_name") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email:">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblemail" Text='<%# Eval("email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txtemail" Text='<%# Eval("email") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact:">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblcont" Text='<%# Eval("contact") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txtcont" Text='<%# Eval("contact") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Password:">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblpass" Text='<%# Eval("password") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txtpass" Text='<%# Eval("password") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date:">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("date") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="190" />
                                </Columns>
                            </asp:GridView>
                        </div>




                    </div>
                </div>
            </div>
        </div>
    </section>



</asp:Content>
