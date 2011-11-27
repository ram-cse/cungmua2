function facebook_login() {
    FB.login(function (response) {
        if (response.session) {
            if (response.perms) {
                FacebookConnectMySite(response.session);
            } else { // user khong cung cap thong tin can thiet ( email )
                FB.logout(function (response) {
                    alert("B?n c?n cung các thông tin c? b?n ?? có th? ??ng nh?p cungmua.com");
                });
            }
        } else {
            // user is not logged in
        }

    }, { perms: 'email' });
}

function FacebookConnectMySite(facebookSession) {
    document.location = SITE_ROOT_URL + '/Customer/FacebookLogin?' + "&uid=" + facebookSession.uid + "&token=" + facebookSession.access_token + "&returnUrl=" + window.location;
}

function Logout() {
    FB.getLoginStatus(handleSessionResponse);
}

function handleSessionResponse(response) {
    if (!response.session) {
        return;
    }

    FB.logout();
}

var FB_SESSION = "";

function AutoDetectLogin(IsAuthenticated, IsFacebookAuthenticated) {
    if(IsAuthenticated == "True") // da dang nhap
    {
        if(IsFacebookAuthenticated == "False") // dang nhap bang groupon
        {
            return;
        }
        else
        {
            FB.getLoginStatus(function (response) { // neu mat facebook session thi tu dong logout
                if (!response.session) {
                    FB.logout();
                    document.location = SITE_ROOT_URL + "/Customer/Logout";
                }
            });
        } 
    }
    else //chua dang nhap
    {
        FB.getLoginStatus(function (response) { // neu ton tai facebook session thi auto login bang facebook
            if (response.session) {
                FacebookConnectMySite(response.session);
            }
        });
    }
}