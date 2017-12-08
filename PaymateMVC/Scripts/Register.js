$(document).ready(function () {
    $('#page-spinner').fadeOut(400);
    AppCommonFunction.HideWaitBlock();
});

var form = $('#reg-log-form');
$('#reg-log-button').click(function () {
    AppCommonFunction.ShowWaitBlock();
    if (form.valid() == false) {
        AppCommonFunction.HideWaitBlock();
    }
});

