$('#page-spinner').fadeIn(400);

$(document).ready(function () {
    $('#page-spinner').fadeOut(400);
});

var AppCommonFunction = function () {
    return {
        ShowWaitBlock: function () {
            $('#page-spinner').fadeIn(400);
        },

        HideWaitBlock: function () {
            $('#page-spinner').fadeOut(400);
        }
    };
}();