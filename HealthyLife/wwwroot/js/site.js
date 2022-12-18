function hover(element) {
    element.setAttribute('src', '../img/icons/hovered_heard.png');
}

function unhover(element) {
    element.setAttribute('src', '../img/icons/hear_ico.png');
}

$(document).ready(function () {
    $('#media').carousel({
        pause: true,
        interval: false,
    });

    var swiper = new Swiper(".mySwiper", {
        slidesPerView: 3,
        spaceBetween: 20,
        slidesPerGroup: 3,
        loop: true,
        loopFillGroupWithBlank: true,
        pagination: {
            el: ".swiper-pagination",
            clickable: true,
        },
        navigation: {
            nextEl: ".swiper-button-next",
            prevEl: ".swiper-button-prev",
        },
    });

    var swiper1 = new Swiper(".mySwiper1", {
        slidesPerView: 3,
        spaceBetween: 20,
        slidesPerGroup: 3,
        loop: true,
        loopFillGroupWithBlank: true,
        pagination: {
            el: ".swiper-pagination1",
            clickable: true,
        },
        navigation: {
            nextEl: ".swiper-button-next1",
            prevEl: ".swiper-button-prev1",
        },
    });

    var swiper2 = new Swiper(".mySwiper2", {
        slidesPerView: 3,
        spaceBetween: 20,
        slidesPerGroup: 3,
        loop: true,
        loopFillGroupWithBlank: true,
        pagination: {
            el: ".swiper-pagination2",
            clickable: true,
        },
        navigation: {
            nextEl: ".swiper-button-next2",
            prevEl: ".swiper-button-prev2",
        },
    });

    $('#list').click(function () {
        $('.list-image').attr('src', '/img/icons/list-active.png');
        $('.grid3-image').attr('src', '/img/icons/grid3.png');
        $('.grid4-image').attr('src', '/img/icons/grid4.png');
        $('.grid5-image').attr('src', '/img/icons/grid5.png');
        $('.list-div').css('display', 'inline');
        $('.grid-div').css('display', 'none');
    });

    $('#grid3').click(function () {
        $('.list-image').attr('src', '/img/icons/list.png');
        $('.grid3-image').attr('src', '/img/icons/grid3-active.png');
        $('.grid4-image').attr('src', '/img/icons/grid4.png');
        $('.grid5-image').attr('src', '/img/icons/grid5.png');
        $('.list-div').css('display', 'none');
        $('.grid-div').css('display', 'flex');
        $('.course').each(function () {
            $(this).removeClass('grid4');
            $(this).removeClass('grid5');
            $(this).addClass('grid3');
        });
    });

    $('#grid4').click(function () {
        $('.list-image').attr('src', '/img/icons/list.png');
        $('.grid3-image').attr('src', '/img/icons/grid3.png');
        $('.grid4-image').attr('src', '/img/icons/grid4-active.png');
        $('.grid5-image').attr('src', '/img/icons/grid5.png');
        $('.list-div').css('display', 'none');
        $('.grid-div').css('display', 'flex');
        $('.course').each(function () {
            $(this).removeClass('grid3');
            $(this).removeClass('grid5');
            $(this).addClass('grid4');
        });
    });

    $('#grid5').click(function () {
        $('.list-image').attr('src', '/img/icons/list.png');
        $('.grid3-image').attr('src', '/img/icons/grid3.png');
        $('.grid4-image').attr('src', '/img/icons/grid4.png');
        $('.grid5-image').attr('src', '/img/icons/grid5-active.png');
        $('.list-div').css('display', 'none');
        $('.grid-div').css('display', 'flex');
        $('.course').each(function () {
            $(this).removeClass('grid3');
            $(this).removeClass('grid4');
            $(this).addClass('grid5');
        });
    });
});

