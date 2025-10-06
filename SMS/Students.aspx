<%@ Page Title="Student Management" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="SMS.Students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card shadow p-4">
        <h3 class="mb-3 text-primary">Student Management</h3>

        <asp:HiddenField ID="hfStudentID" runat="server" />

        <div class="row mb-3">
            <div class="col-md-3">
                <asp:Label ID="lblName" runat="server" Text="Name:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lblAge" runat="server" Text="Age:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-3">
                <asp:Label ID="lblClass" runat="server" Text="Class:" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtClass" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="col-md-3 d-flex align-items-end">
                <asp:Button ID="btnAdd" runat="server" Text="Add Student" CssClass="btn btn-success w-100" OnClick="btnAdd_Click" />
            </div>
        </div>

        <hr />

        <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-striped"
            AutoGenerateColumns="False" DataKeyNames="StudentID"
            OnRowEditing="GridView1_RowEditing"
            
            
            OnRowDeleting="GridView1_RowDeleting">

            <Columns>
                <asp:BoundField DataField="StudentID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Age" HeaderText="Age" />
                <asp:BoundField DataField="Class" HeaderText="Class" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
