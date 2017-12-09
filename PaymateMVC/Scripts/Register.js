$(document).ready(function () {
    $('#page-spinner').fadeOut(400);
    AppCommonFunction.HideWaitBlock();
});

var form = $('#reg-log-form');
$('#reg-log-button').click(function () {
   
    if (form.valid() == false) {
        AppCommonFunction.HideWaitBlock();
    }
    else {
        AppCommonFunction.ShowWaitBlock();
    }
});

