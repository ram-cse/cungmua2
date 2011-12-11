<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Final.Home" %>

<%@ Register src="GoogleMapForASPNet.ascx" tagname="GoogleMapForASPNet" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
    
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 63px;
        }
        .style4
        {
            height: 63px;
            width: 301px;
        }
        .style5
        {
            width: 302px;
        }
        .style6
        {
            width: 674px;
        }
        .style8
        {
            width: 59px;
            background-color: Aqua;
        }
        .style10
        {
            height: 237px;
            width: auto;
            background: url(http://media.noupe.com//uploads/2011/06/Reach-For-The-Future-Original.jpg);
        }
        .style11
        {
            height: 237px;
        }
        .style12
        {
            width: 784px;
            height: 23px;
        }
        .style13
        {
            height: 237px;
            width: 59px;
        }
        .style14
        {
            height: 63px;
            width: 59px;
        }
        .style15
        {
            width: 59px;
        }
        </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <table class="style1">
        <tr>
            <td class="style13">
                </td>
            <td colspan="2" class="style10">
                <br />
                <br />
                </td>
            <td class="style11">
                </td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td colspan="2" class="style4">

                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style8" rowspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td  rowspan="2">
                <asp:DataList ID="DataList1" runat="server" 
                    onitemcommand="DataList1_ItemCommand" style="text-align: left">
                    <ItemTemplate>
                        <asp:ImageButton CssClass="left" ID="ImageButton1" runat="server" Height="120px" 
                            ImageUrl='<%# "/images/"+DataBinder.Eval(Container.DataItem, "image") %>' 
                            Width="100px" />
                        <br />
                        <asp:HiddenField ID="HiddenField1" runat="server" 
                            Value='<%# Bind("ProductId") %>' />
                        <br />
                        <asp:HiddenField ID="HiddenField2" runat="server" 
                            Value='<%# Bind("ProductName") %>' />
                        <br />
                        <asp:HiddenField ID="HiddenField3" runat="server" 
                            Value='<%# Bind("ExpirationDate") %>' />
                    </ItemTemplate>
                </asp:DataList>
            </td>

            <td class="style6">
                <asp:DataList ID="DataList2" runat="server">
                    <ItemTemplate>
                        <table class="style1">
                            <tr>
                                <td>
                                    <asp:Image ID="Image2" runat="server" 
                                        ImageUrl='<%# "/images/"+DataBinder.Eval(Container.DataItem, "image") %>' />
                                </td>
                                <td>
                                    <h2> Thời gian còn lại </h2><br />
                                    <h2><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></h2>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageButton2" runat="server" 
                                        ImageUrl="/images/buttonMuaNgay.png" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>
            <td rowspan="5" class="style5">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style12">
                </td>
        </tr>
        <tr>
            <td  rowspan="2">
                &nbsp;</td>
            <td class="style6">
                <asp:DataList ID="DataList3" runat="server">
                    <ItemTemplate>
                        <asp:Image ID="Image1" CssClass="none" runat="server" ImageUrl='<%# Bind("ImagePath") %>' />
                    </ItemTemplate>
                </asp:DataList>
            </td>
        </tr>
        <tr>
            <td class="style15">
            <div>
                <uc1:GoogleMapForASPNet ID="GoogleMapForASPNet1" runat="server" />
                <br />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
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
