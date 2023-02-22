<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Studentlist.aspx.cs" Inherits="HRM.Studentlist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:LinkButton ID="lnk" Text="New Employee" runat="server" OnClick="lnk_Click"></asp:LinkButton>
    <br />

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%" OnRowCommand="GridView1_RowCommand">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="ID">
               
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("EmployeeId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EmpName" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Phone" HeaderText="Phone" />
            <asp:BoundField DataField="DepName" HeaderText="Department" />
            <asp:BoundField DataField="DesignationName" HeaderText="Designation" />
            <asp:BoundField DataField="BasicSalary" HeaderText="Salary" />
           
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEdit" runat="server"  CommandArgument='<%# Eval("EmployeeId") %>' CommandName="Edt" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
                 </asp:TemplateField>
           
                 <asp:TemplateField>
                    
                <ItemTemplate>
                    <asp:LinkButton ID="lnkDelete" runat="server"  CommandArgument='<%# Eval("EmployeeId") %>' CommandName="del" Text="Delete"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
</asp:GridView>


</asp:Content>
