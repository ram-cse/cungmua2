<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PP.aspx.cs" Inherits="ThichThiMua.PP" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Phieu/San pham" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Amount" HeaderText="Amount" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:TextBox ID="txtOrderAmount" runat="server"></asp:TextBox>
        <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
            Text="Button" />
        <br />
        <asp:TextBox ID="txtCCType" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblErrorMessage" runat="server" Text="Label"></asp:Label>
    
    </div>
    </form>
</body>
</html>
