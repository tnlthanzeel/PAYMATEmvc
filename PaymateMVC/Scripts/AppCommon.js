$('#page-spinner').show();

$(document).ready(function () {
    $('#page-spinner').hide();
});

var AppCommonFunction = function () {
    return {
        ShowWaitBlock: function () {
            $('#page-spinner').show();
        },

        HideWaitBlock: function () {
            $('#page-spinner').hide();
        }
    };
}();