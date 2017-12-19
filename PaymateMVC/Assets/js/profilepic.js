//$(document).ready(function () {


//    var readURL = function (input) {
//        if (input.files && input.files[0]) {
//            var reader = new FileReader();

//            reader.onload = function (e) {
//                $('.profile-pic').attr('src', e.target.result);
//            }

//            reader.readAsDataURL(input.files[0]);
//        }
//    }


//    $(".file-upload").on('change', function () {
//        readURL(this);
//    });

//    $(".upload-button").on('click', function () {
//        $(".file-upload").click();
//    });
//});

var imgUrl = $('#profilrPicUrl').val();

var basic = $('#main-cropper').croppie({
    enableExif: true,
    viewport: {
        width: 175,
        height: 175,
        type: 'circle'

    },
    boundary: { width: 300, height: 300 },
    showZoomer: true,
    //enableOrientation: true
});


function readFile(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#main-cropper').croppie('bind', {
                url: e.target.result
            });
            $('.actionDone').toggle();
            $('.actionUpload').toggle();
        }

        reader.readAsDataURL(input.files[0]);
    }
}

$('.actionUpload input').on('change', function () { readFile(this); });
$('.actionDone').on('click', function () {
    $('.actionDone').toggle();
    $('.actionUpload').toggle();
})




