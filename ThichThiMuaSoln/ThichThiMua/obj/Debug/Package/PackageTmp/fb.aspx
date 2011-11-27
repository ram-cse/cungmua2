<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fb.aspx.cs" Inherits="ThichThiMua.fb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml"   xmlns:fb="http://www.facebook.com/2008/fbml">  
<head runat="server">
    <title></title>
    <script src="http://static.ak.connect.facebook.com/js/api_lib/v0.4/FeatureLoader.js.php"
        type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table width="100%" border="0">
            <tr>
                <td>
                    <fb:login-button onclick="http://www.google.com" onlogin="window.location.reload()">
        </fb:login-button>
                    &nbsp;
                    <fb:prompt-permission perms="email"> Grant application users to mail me </fb:prompt-permission>
                </td>
            </tr>
            <tr>
                <td align="left" valign="top">
                    Your Facebook Name:<asp:Label ID="lblName" runat="server" Text="Not authenticated."></asp:Label>
                </td>
            </tr>
            </table>
    </div>
    </form>
    <script type="text/javascript">
        FB.init("138943712879163", "xd_receiver.htm");
    </script>
</body>
</html>
