<%@ Page Title="" Language="C#" MasterPageFile="~/TTM.Master" AutoEventWireup="true" CodeBehind="order.aspx.cs" Inherits="ThichThiMua.order" ClientIDMode="Static" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <p>
        Đăng ký mua hàng</p>
    <p>
        Vui lòng chọn số lượng</p>
    <p>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            ShowFooter="True" style="margin-right: 4px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Phiếu/Sản phẩm" />
                <asp:TemplateField HeaderText="Price">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" ClientIDMode="Static" Text='<%# Bind("Price") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" ClientIDMode="Static" Text='<%# Bind("Quantity") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Amount">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Amount") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </p>
    <p>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </p>
    <p>
        <asp:Button ID="buttonCheckOut" runat="server" PostBackUrl="preorder.aspx" 
            Text="Check Out" />
    </p>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
