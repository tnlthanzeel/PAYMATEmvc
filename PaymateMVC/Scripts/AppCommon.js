$('#page-spinner').show();

$(document).ready(function () {
    $('#page-spinner').hide();
});

var AppCommonFunction = function () {
    return {
        ShowWaitBlock: function () {
            $('#page-spinner').fadeIn(400);
        },

        HideWaitBlock: function () {
            $('#page-spinner').fadeOut(300);
        }
    };
}();