$(function () {
    $(".datepicker").datepicker({
        dateFormat: "dd/mm/yy",
        changeMonth: true,
        changeYear: true,
        yearRange: "-70:+0",
        showOn: "both",
        buttonText: "<i class='fa fa-calendar'></i>"
    });
});