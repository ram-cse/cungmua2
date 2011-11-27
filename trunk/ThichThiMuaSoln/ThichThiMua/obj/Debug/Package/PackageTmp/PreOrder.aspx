<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreOrder.aspx.cs" Inherits="ThichThiMua.PreOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:RadioButton ID="RadioButton1" runat="server" Text="You have account" />
        <br />
        <asp:RadioButton ID="RadioButton2" runat="server" 
            oncheckedchanged="RadioButton2_CheckedChanged" Text="You are new member" />
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click1" 
            Text="Ngan luong" />
        <br />
        <br />
        
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            Height="125px" ShowFooter="True" Width="276px">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Phieu/San pham" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" />
            </Columns>
        </asp:GridView>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
