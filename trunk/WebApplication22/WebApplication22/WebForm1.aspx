<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication22.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div >
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
    </div>

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
        document.getElementById("Label1").innerHTML=remain;
}
</script>
</body>
</html>
