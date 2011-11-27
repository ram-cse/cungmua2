<%@ Page Title="" Language="C#" MasterPageFile="~/TTM.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ThichThiMua.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>



        


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>

        <br />
    </p>
            <asp:DataList ID="DataList1" runat="server" 
                onitemcommand="DataList1_ItemCommand">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" 
                        ImageUrl='<%# "/images/"+DataBinder.Eval(Container.DataItem, "image") %>' 
                        onclick="ImageButton1_Click" Height="154px" />
        <br />
                    <asp:HiddenField ID="HiddenField1" runat="server" 
                        Value='<%# Bind("ProductId") %>' />
                    <asp:HiddenField ID="HiddenField2" runat="server" 
                        Value='<%# Bind("ProductName") %>' />
        <br />
                </ItemTemplate>
            </asp:DataList>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
<asp:Content ID="Content3" runat="server" 
    contentplaceholderid="ContentPlaceHolder2">
    <asp:DataList ID="DataList2" runat="server">
        <ItemTemplate>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Bind("ImagePath") %>' />
            <br />
            <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>

<asp:Content ID="Content4" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
    <p>
    &nbsp;&nbsp;&nbsp;&nbsp; <asp:DataList ID="DataList3" runat="server" Width="63px" 
            onupdatecommand="DataList3_UpdateCommand">
        <ItemTemplate>
            &nbsp;<asp:Image ID="Image2" runat="server" 
    ImageUrl='<%# "/images/"+DataBinder.Eval(Container.DataItem, "image") %>' />
            <br />
            <asp:HiddenField ID="HiddenField3" runat="server" 
                Value='<%# Bind("ProductId") %>' />
            <asp:HiddenField ID="HiddenField4" runat="server" 
                Value='<%# Bind("Price") %>' />
            <br />
            <asp:ImageButton ID="ImageButton3" runat="server" 
                ImageUrl="images/logo/buttonMuaNgay.png" onclick="ImageButton3_Click1" 
                CommandName="Update" />
            <br />
        </ItemTemplate>
    </asp:DataList>
    </p>
    <p>
        &nbsp;&nbsp;</p>
</asp:Content>


<asp:Content ID="Content5" runat="server" 
    contentplaceholderid="ContentPlaceHolder4">
    <asp:DropDownList ID="DropDownList1" runat="server">
</asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
</asp:Content>



