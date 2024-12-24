<%@ Page Title="" Language="C#" MasterPageFile="~/Admin Control/AdminDairyFarm.Master" AutoEventWireup="true" CodeBehind="AdminRegistration.aspx.cs" Inherits="WebApplication1.Admin_Control.AdminRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .body {
        font-family: "Saira", sans-serif!important;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="body">   
        <div class="pagetitle">
      <h1>Admin Registration</h1>
      <nav>
          <ol class="breadcrumb">
              <li class="breadcrumb-item"><a href="index.html">Home</a></li>
              <li class="breadcrumb-item active">Admin Registation</li>
          </ol>
      </nav>
  </div>


        <section class="section">
        <div class="row" style="margin-top:80px;">
            <div class="col-lg-12">

                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Registered</h5>


                        <div class="table-responsive">
                            <asp:GridView runat="server" ID="gridv" DataKeyNames="srno" AutoGenerateColumns="false" OnRowEditing="gridv_RowEditing" OnRowCancelingEdit="gridv_RowCancelingEdit" OnRowUpdating="gridv_RowUpdating" OnRowDeleting="gridv_RowDeleting" CssClass="table " Style="text-align: center; margin-top: 90px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Admin Id:">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblname" Text='<%# Eval("admin_id") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox runat="server" ID="txtname" Text='<%# Eval("admin_id") %>'></asp:TextBox>
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
                                    
                                    <asp:CommandField ButtonType="Button" ShowEditButton="true" ShowDeleteButton="true" ItemStyle-Width="190" />
                                </Columns>
                            </asp:GridView>
                        </div>




                    </div>
                </div>
            </div>
        </div>
    </section>
        </div>







</asp:Content>
