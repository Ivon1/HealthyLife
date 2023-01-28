$(document).ready(() => {    
    $('#rate_one').hover(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_two_img').attr("src", "/img/icons/rate.png");
        $('#rate_three_img').attr("src", "/img/icons/rate.png");
        $('#rate_four_img').attr("src", "/img/icons/rate.png");
        $('#rate_five_img').attr("src", "/img/icons/rate.png");
    }, function () {
        if (!$(this).hasClass('rated')) {
            $('#rate_one_img').attr("src", "/img/icons/rate.png");
            $('#rate_two_img').attr("src", "/img/icons/rate.png");
            $('#rate_three_img').attr("src", "/img/icons/rate.png");
            $('#rate_four_img').attr("src", "/img/icons/rate.png");
            $('#rate_five_img').attr("src", "/img/icons/rate.png");
        }
    });

    $('#rate_one').click(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('.rate_count').val(1);
        console.log($('.rate_count').val());
        $(this).addClass('rated');
        $('#rate_two').removeClass('rated');
        $('#rate_three').removeClass('rated');
        $('#rate_four').removeClass('rated');
        $('#rate_five').removeClass('rated');
    });

    $('#rate_two').hover(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_two_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_three_img').attr("src", "/img/icons/rate.png");
        $('#rate_four_img').attr("src", "/img/icons/rate.png");
        $('#rate_five_img').attr("src", "/img/icons/rate.png");
    }, function () {
        if (!$(this).hasClass('rated')) {
            $('#rate_one_img').attr("src", "/img/icons/rate.png");
            $('#rate_two_img').attr("src", "/img/icons/rate.png");
            $('#rate_three_img').attr("src", "/img/icons/rate.png");
            $('#rate_four_img').attr("src", "/img/icons/rate.png");
            $('#rate_five_img').attr("src", "/img/icons/rate.png");
        }
    });

    $('#rate_two').click(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_two_img').attr("src", "/img/icons/rate-orange.png");
        $('.rate_count').val(2);
        console.log($('.rate_count').val());
        $(this).addClass('rated');
        $('#rate_one').removeClass('rated');
        $('#rate_three').removeClass('rated');
        $('#rate_four').removeClass('rated');
        $('#rate_five').removeClass('rated');
    });

    $('#rate_three').hover(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_two_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_three_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_four_img').attr("src", "/img/icons/rate.png");
        $('#rate_five_img').attr("src", "/img/icons/rate.png");
    }, function () {
        if (!$(this).hasClass('rated')) {
            $('#rate_one_img').attr("src", "/img/icons/rate.png");
            $('#rate_two_img').attr("src", "/img/icons/rate.png");
            $('#rate_three_img').attr("src", "/img/icons/rate.png");
            $('#rate_four_img').attr("src", "/img/icons/rate.png");
            $('#rate_five_img').attr("src", "/img/icons/rate.png");
        }       
    });

    $('#rate_three').click(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_two_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_three_img').attr("src", "/img/icons/rate-orange.png");
        $('.rate_count').val(3);
        console.log($('.rate_count').val());
        $(this).addClass('rated');
        $('#rate_one').removeClass('rated');
        $('#rate_two').removeClass('rated');
        $('#rate_four').removeClass('rated');
        $('#rate_five').removeClass('rated');
    });

    $('#rate_four').hover(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_two_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_three_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_four_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_five_img').attr("src", "/img/icons/rate.png");
    }, function () {
        if (!$(this).hasClass('rated')) {
            $('#rate_one_img').attr("src", "/img/icons/rate.png");
            $('#rate_two_img').attr("src", "/img/icons/rate.png");
            $('#rate_three_img').attr("src", "/img/icons/rate.png");
            $('#rate_four_img').attr("src", "/img/icons/rate.png");
            $('#rate_five_img').attr("src", "/img/icons/rate.png");
        }
    });

    $('#rate_four').click(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_two_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_three_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_four_img').attr("src", "/img/icons/rate-orange.png");
        $('.rate_count').val(4);
        console.log($('.rate_count').val());
        $(this).addClass('rated');
        $('#rate_one').removeClass('rated');
        $('#rate_two').removeClass('rated');
        $('#rate_three').removeClass('rated');
        $('#rate_five').removeClass('rated');
    });

    $('#rate_five').hover(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_two_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_three_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_four_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_five_img').attr("src", "/img/icons/rate-orange.png");       
    }, function () {
        if (!$(this).hasClass('rated')) {
            $('#rate_one_img').attr("src", "/img/icons/rate.png");
            $('#rate_two_img').attr("src", "/img/icons/rate.png");
            $('#rate_three_img').attr("src", "/img/icons/rate.png");
            $('#rate_four_img').attr("src", "/img/icons/rate.png");
            $('#rate_five_img').attr("src", "/img/icons/rate.png");
        }     
    });

    $('#rate_five').click(function () {
        $('#rate_one_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_two_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_three_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_four_img').attr("src", "/img/icons/rate-orange.png");
        $('#rate_five_img').attr("src", "/img/icons/rate-orange.png");
        $('.rate_count').val(5);
        console.log($('.rate_count').val());
        $(this).addClass('rated');
        $('#rate_one').removeClass('rated');
        $('#rate_two').removeClass('rated');
        $('#rate_three').removeClass('rated');
        $('#rate_four').removeClass('rated');
    });

    let courseId = $('.courseId').val();
    console.log(courseId);
    $.ajax({
        type: 'POST',
        url: '/CourseRates/GetRateInfo',
        data: { courseId: courseId },
        dataType: 'json',
        success: function (result) {
            console.log(result);
            let count = parseInt(result.count);
            let totalRate = parseInt(result.totalRate);
            let averRate = totalRate / count;
            console.log("AverRate = " + averRate);
            if (averRate >= 0.5 && averRate < 1.5) {
                $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
            }
            if (averRate >= 1.5 && averRate < 2.5) {
                $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_two').attr("src", "/img/icons/rate-orange.png");
            }
            if (averRate >= 2.5 && averRate < 3.5) {
                $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_two').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_three').attr("src", "/img/icons/rate-orange.png");
            }
            if (averRate >= 3.5 && averRate < 4.5) {
                $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_two').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_three').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_four').attr("src", "/img/icons/rate-orange.png");
            }
            if (averRate >= 4.5 && averRate < 5) {
                $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_two').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_three').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_four').attr("src", "/img/icons/rate-orange.png");
                $('.rate_course_five').attr("src", "/img/icons/rate-orange.png");
            }
            $('#aver-rate').html(averRate.toString().replace('.', ',') + ' / 5');
        }
    });

    $('.rating-catalog').each(function () {
        let courseCatalogId = $('.courseCatalogId').val();
        console.log(courseCatalogId);
    })

    $('#add-rate').click((event) => {
        let target = $(event.target);
        let parent = target.parent();
        let hidden1 = parent.find('.courseId');
        let hidden2 = parent.find('.rate_count');
        let _courseId = parseInt(hidden1.val());
        let _rate = parseInt(hidden2.val());
        alert(`Курсу із ID ${_courseId} успішно поставлено оцінку ${_rate}`);
        $.ajax({
            type: 'POST',
            url: '/CourseRates/AddRate',
            data: { courseId: _courseId, rate: _rate },
            dataType: 'json',
            success: function (result) {
                console.log(result);
                let count = parseInt(result.count);
                let totalRate = parseInt(result.totalRate);
                let averRate = totalRate / count;
                if (averRate >= 0.5 && averRate < 1.5) {
                    $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
                }
                if (averRate >= 1.5 && averRate < 2.5) {
                    $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_two').attr("src", "/img/icons/rate-orange.png");
                }
                if (averRate >= 2.5 && averRate < 3.5) {
                    $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_two').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_three').attr("src", "/img/icons/rate-orange.png");
                }
                if (averRate >= 3.5 && averRate < 4.5) {
                    $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_two').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_three').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_four').attr("src", "/img/icons/rate-orange.png");
                }
                if (averRate >= 4.5 && averRate < 5) {
                    $('.rate_course_one').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_two').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_three').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_four').attr("src", "/img/icons/rate-orange.png");
                    $('.rate_course_five').attr("src", "/img/icons/rate-orange.png");
                }
                $('#aver-rate').html(averRate + ' / 5');
            }
        });
    })
});