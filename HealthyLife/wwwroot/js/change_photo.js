$(document).ready(function () {

    $("#images").on("change", function () {
        var preview = $("#img-profile");
        var file = this.files[0];
        var reader = new FileReader();

        reader.onloadend = function () {
            preview.attr("src", reader.result);
        }

        if (file) {
            reader.readAsDataURL(file);
        }
    });

    $(".df-photo").on("click",function () {
        var src = $(this).attr("src");
        $("#img-profile").attr("src", src);
        $("#photo-gal").val(src);
    });

});