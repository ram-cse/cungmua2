<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication22.WebForm2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="lib/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="lib/jquery.ui.datepicker.js" type="text/javascript"></script>
    <script src="lib/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>
    <link href="lib/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
 
    <script language="javascript" type="text/javascript">
        $(function () {
            $("#txtCalendar").datepicker({ changeYear: true, yearRange: '2011:2012' });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-left: 40px">
    
        <asp:DataList ID="DataList1" runat="server" 
            onitemcommand="DataList1_ItemCommand">
            <ItemTemplate>
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Bind("Time") %>' />
                <br />
                <asp:Button ID="Button2" runat="server" Text='<%# Bind("id") %>' />
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
        <asp:DataList ID="DataList2" runat="server" 
            onitemcommand="DataList2_ItemCommand">
            <ItemTemplate>
                <asp:Label ID="Label2" runat="server" ></asp:Label>
                <br />
            </ItemTemplate>
        </asp:DataList>
        <br />
        <br />
        <br />
    
        <asp:TextBox ID="txtCalendar" runat="server"></asp:TextBox>
    
        <br />
    
        <br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
        <br />
        <asp:Button ID="Button2" runat="server" onclick="Button1_Click" Text="Button" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>
    <div id="timer"></div>
    </form>
    <script type="text/javascript">
        var leave = <%=seconds %>;
        CounterTimer();
        var interv=setInterval(CounterTimer,1000);
        function CounterTimer()
        {
        var day = Math.floor(leave / ( 60 * 60 * 24))
        var hour = Math.floor(leave / 3600) - (day * 24)
        var minute = Math.floor(leave / 60) - (day * 24 *60) - (hour * 60)
        var second = Math.floor(leave) - (day * 24 *60*60) - (hour * 60 * 60) - (minute*60)
        hour=hour<10 ? "0" + hour : hour;
        minute=minute<10 ? "0" + minute : minute;
        second=second<10 ? "0" + second : second;
        var remain=day + " days   "+hour + ":"+minute+":"+second;
        leave=leave-1;
        document.getElementById("DataList2_Label2_0").innerHTML=remain;
}
</script>
</body>
</html>
