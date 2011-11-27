<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="ThichThiMua.SignUp" %>

<%@ Register assembly="MSCaptcha" namespace="MSCaptcha" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    First Name</td>
                <td>
                    <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name</td>
                <td>
                    <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    User Name</td>
                <td>
                    <asp:TextBox ID="TextBoxUserName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Email</td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Password</td>
                <td>
                    <asp:TextBox ID="TextBoxPassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Retype Password</td>
                <td>
                    <asp:TextBox ID="TextBoxRetypePassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Mã xác nhận</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <cc1:CaptchaControl ID="CaptchaControl1" runat="server" CaptchaBackgroundNoise="Medium" CaptchaLineNoise="Low" />
                </td>
                <td>
                    <asp:TextBox ID="TextBoxCaptcha" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="ButtonSignUp" runat="server" Text="Sign Up" 
                        onclick="btnSignUp_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
