$(document).ready(function () {
    $('#page-spinner').hide();
    AppCommonFunction.HideWaitBlock();
});

var formregister = $("#register-form");

$('#register-spinner').click(function () {
    AppCommonFunction.ShowWaitBlock();
    if (formregister.valid() == false) {
        AppCommonFunction.HideWaitBlock();
    }
});

var formlogin = $("#login-form");

$('#login-spinner').click(function () {
    AppCommonFunction.ShowWaitBlock();
    if (formlogin.valid() == false) {
        AppCommonFunction.HideWaitBlock();
    }
});

