var GetCookieValue = function (cookies, cookieName) {
    return cookies.split('; ')
        .find(row => row.startsWith(cookieName))
        ?.split('=')[1];
};

var SetCookieValue = function (cookieName, cookieValue) {
    return cookieName + "=" + cookieValue + ";";
};

var isAuthorised = function () {
    let currentUser = GetCookieValue(document.cookie, "currentUser");

    return !(!currentUser || currentUser == "undefined");
}

var currentUser = function () {
    return GetCookieValue(document.cookie, "currentUser");
};

var setCurrentUserName = function (name) {

    var userName = document.getElementById('current-user-name');
    userName.innerText = name;
};

var setButtonOnClickHandler = function (buttonId, handler) {
    let Button = document.getElementById(buttonId);
    Button.onclick = handler;
};

var logOutButtonHandler = function () {
    document.cookie = SetCookieValue("currentUser", undefined);
    document.cookie = SetCookieValue("currentUserId", undefined);
    setCurrentUserName("Not authorized");
    localStorage.removeItem("accessToken");
    localStorage.removeItem("refreshToken");
    hideShowStaffInfornmation();
};

var hideShowStaffInfornmation = function (flag = true) {
    let container = document.getElementById('accordionStaffPage');
    container.hidden = flag;
};

var loginButtonHandler = function () {

    var modalBody = document.getElementById('login-as-staff-client-modal');

    if (!modalBody.hidden) {

        $('#login-as-staff-client-modal').modal('hide')
    }

    var confirmPasswordRow = modalBody.querySelector('#confirm-password-row');

    if (!confirmPasswordRow.hidden) {

        registerNewClientRequest();
        return;
    };

    var name = modalBody.querySelector('.user-name').value;
    var pass = modalBody.querySelector('.user-password').value;
    var staff = modalBody.querySelector('.user-staff').value;

    var ajaxParameters = {
        url: "/Authentification/Authenticate?login=" + name + "&password=" + pass + "&itStaff=" + Boolean(staff),
        type: "POST",
        cache: false,
        contentType: "application/json; charset=utf-8",
        success: afterAuthTokensRequest, 

        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'Authentification');
        }
    };

    $.ajax(ajaxParameters);
};

var afterAuthTokensRequest = function (response) {

    if (!response.isSuccess) {
        alert(response.message);
        showAuthantificationModal();
        return;
    }

    localStorage.setItem("accessToken", response.token);
    localStorage.setItem("refreshToken", response.refreshToken);

    getAuthorizedUserData();
}

var getAuthorizedUserData = function () {

    var ajaxParameters = {
        url: "/Users/GetCurrentAuthorizedUser",
        type: "GET",
        cache: false,
        beforeSend: addTokenToRequest,
        contentType: "application/json; charset=utf-8",
        success: function (userDTO) {

            setCurrentUserName(userDTO.login);
            document.cookie = SetCookieValue("currentUser", userDTO.login);
            document.cookie = SetCookieValue("currentUserId", userDTO.id);

            if (userDTO.staff)
                loadStaffPageDataIfAuthorised();
            else {

                changeRegButtonsVisiblity();
                loadPassengersForUser();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'verifying user');
            showAuthantificationModal();
            return;
        }
    }

    $.ajax(ajaxParameters);
}

var checkAuthorisation = function (onlyPing = false) {

    //debugger;
    var token = localStorage.getItem("accessToken");

    if (!token) {
        showAuthantificationModal();
        return;
    }
    var ajaxParameters = {
        url: '/Authentification/PingJWTToken',
        async: false,
        type: "Get",
        cache: false,
        beforeSend: addTokenToRequest,
        success: function (response) {
            if (!onlyPing) {
                setCurrentUserName(currentUser());
                loadStaffPageDataIfAuthorised();
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

            updateTokens();
        }
    }

    $.ajax(ajaxParameters);
};

var updateTokens = function () {

    var tokens = JSON.stringify({
        token: localStorage.getItem("accessToken"),
        refreshToken: localStorage.getItem("refreshToken")
    });

    var ajaxParameters = {
        url: '/Authentification/UpdateToken',
        type: "Post",
        contentType: "application/json; charset=utf-8",
        cache: false,
        async: false,
        data: tokens,
        success: afterAuthTokensRequest,
        error: function (jqXHR, textStatus, errorThrown) {

            hideShowStaffInfornmation(true);

            showAuthantificationModal();
        }
    }

    $.ajax(ajaxParameters);

}

var showAuthantificationModal = function () {

    let modal = document.getElementById('login-as-staff-client-modal');
    modal.querySelector('.user-staff').value = true;
    modal.querySelector('#confirm-password-row').hidden = true;
    let myModal = new bootstrap.Modal(modal, {});
    myModal.toggle();
}

var registerNewClientRequest = function () {

    var modalBody = document.getElementById('login-as-staff-client-modal');
    var name = modalBody.querySelector('.user-name').value;
    var pass = modalBody.querySelector('.user-password').value;
    var confpass = modalBody.querySelector('.user-confirm-password').value;
    var staff = modalBody.querySelector('.user-staff').value;

    if (pass != confpass) {

        let myModal = new bootstrap.Modal(modalBody, {});
        myModal.toggle();

        alert("Password and confirm must be equal");

        return;
    }

    let user = JSON.stringify({
        "login": name,
        "password": pass,
        "staff": Boolean(staff)
    });

    let url = "/Users/CreateNewUser";

    let ajaxParameters = {
        url: url,
        type: "POST",
        cache: false,
        contentType: "application/json; charset=utf-8",
        data: user,
        success: function (response) {

            if (!response.result) {
                alert(response.message);
                var myModal = new bootstrap.Modal(document.getElementById('login-as-staff-client-modal'), {});
                myModal.toggle();
                return;
            }

            document.cookie = SetCookieValue("currentUser", name);
            document.cookie = SetCookieValue("currentUserId", response.id);

            setCurrentUserName(name);

            if (staff)
                loadStaffPageDataIfAuthorised();
            else
                changeRegButtonsVisiblity();
        },
        error: function (jqXHR, textStatus, errorThrown) {

            requestErrorHandler(textStatus, jqXHR.status, undefined, 'creating user');
        }
    };

    $.ajax(ajaxParameters);

};

var loginClient = function () {

    clearModalInputs('login-as-staff-client-modal', ['.user-name', '.user-password', '.user-confirm-password', '.user-staff']);

    let modal = document.getElementById('login-as-staff-client-modal');
    modal.querySelector('.user-staff').value = null;
    modal.querySelector('#confirm-password-row').hidden = true;

    var myModal = new bootstrap.Modal(modal, {});
    myModal.toggle();
};


var logOutClient = function () {

    document.cookie = SetCookieValue("currentUser", undefined);
    document.cookie = SetCookieValue("currentUserId", undefined);
    setCurrentUserName("Not authorized");
    changeRegButtonsVisiblity();
    fillUserPassengersSelectionList([]);
};

var registrationNewClient = function () {

    clearModalInputs('login-as-staff-client-modal', ['.user-name', '.user-password', '.user-confirm-password', '.user-staff']);

    let modal = document.getElementById('login-as-staff-client-modal');
    modal.querySelector('.user-staff').value = null;
    modal.querySelector('#confirm-password-row').hidden = false;

    var myModal = new bootstrap.Modal(modal, {});
    myModal.toggle();
};

var addTokenToRequest = function (request) {
    request.setRequestHeader("Authorization", "Bearer " + localStorage.getItem("accessToken"));
}

var beforeSendCRUD = function (request) {

    //debugger;
    checkAuthorisation(true);
    addTokenToRequest(request);        
}

