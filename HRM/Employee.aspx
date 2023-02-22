<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="HRM.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
  <div class="form-group">
    <label for="EmpName">Employee Name</label>
      <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter your name"></asp:TextBox>
    <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
  </div>
 <div class="form-group">
    <label for="Email">Email</label>
      <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="Enter your Email"></asp:TextBox>
  </div>
  <div class="form-group">
    <label for="Phone">Phone</label>
      <asp:TextBox ID="txtphone" runat="server" CssClass="form-control" placeholder="Enter your Phone"></asp:TextBox>
  </div>
    <div class="form-group">
    <label for="EmpName">Department</label>
<asp:DropDownList ID="dept" runat="server" CssClass="form-control"></asp:DropDownList>
  </div>
    <div class="form-group">
    <label for="EmpName">Designation</label>
<asp:DropDownList ID="DrpDesignatgion" runat="server" CssClass="form-control"></asp:DropDownList>
  </div>
    <div class="form-group">
    <label for="EmpName">Basic Salary</label>
      <asp:TextBox ID="txtsalary" runat="server" CssClass="form-control" placeholder="Enter your Basic Salary"></asp:TextBox>
  </div>

    <asp:Button Text="Submit" runat="server" ID="btnSubmit" OnClick="btnSubmit_Click" />
</asp:Content>
