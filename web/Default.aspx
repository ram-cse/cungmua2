<%@ Page Language="C#" AutoEventWireup="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"></head><body>


	


	
	<%-- This is the facebook's login button.
	The "perms" attribute specifies additional user info we want from Facebook - "email".
	You can remove the attribute if not needed, or add more "perms". See FB docs for more info.
	Also, please note the "onlogin" attribute!!! - it tells where to redirect the browser after a successfull login --%>
	
	<fb:login-button perms="email" onlogin="document.location.href = 'callback.aspx'">Login with Facebook</fb:login-button>









	<%-- now this is some required facebook's JS
	the only thing to pay attention to - is setting the ApplicationID, see? line 26...
	To make this project work you have to edit "callback.aspx.cs" and put your facebook-app-key there--%>
	<div id="fb-root"></div>
	<script type="text/javascript">
		window.fbAsyncInit = function () {
			FB.init({ appId: '<%= FacebookLogin.callback.FaceBookAppKey %>', status: true, cookie: true,
				xfbml: true
			});
		};
		(function () {
			var e = document.createElement('script'); e.async = true;
			e.src = document.location.protocol +
			'//connect.facebook.net/en_US/all.js';
			document.getElementById('fb-root').appendChild(e);
		} ());

	</script>






</body></html>