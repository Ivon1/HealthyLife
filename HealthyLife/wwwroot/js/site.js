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

    $('.filter').click(function () {
        $('.subject-list').css('display', 'flex');
        $('.arrow').css('color', '#F25564');
    });

    // auth functions
    var nameCheck = false;
    var lastNameCheck = false;
    var emailCheck = false;
    var emailCheck = false;
    var passwCheck = false;
    var passwConfCheck = false;
    var checkbox1 = false;
    var checkbox2 = false;

    $('#email-input').keyup(function () {
        var emailRegex = /[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/;
        if (!emailRegex.test(this.value)) {
            $(this).addClass("error");
            $(this).removeClass("ok-input");
        } else {
            $(this).removeClass("error");
            $(this).addClass("ok-input");
        }
    });

    $('#name-input').on('input',function () {
        var nameregex = /[a-zA-Zа-яА-Яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ]$/;
        if (!nameregex.test(this.value)) {

            $(this).addClass("error");
            $(this).removeClass("ok-input");

            $('#name-res').text('некоректне ім’я');
            $('#name-res').addClass('res-fail');

            nameCheck = false;
            checkIsAllValidated();
        } else {
            $(this).removeClass("error");
            $(this).addClass("ok-input");  

            $('#name-res').text('✅');
            $('#name-res').addClass('res-succ');

            nameCheck = true;
            checkIsAllValidated();
        }
    });

    $('#last-name-input').on('input', function () {
        var nameregex = /[a-zA-Zа-яА-Яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ]$/;
        if (!nameregex.test(this.value)) {

            $(this).addClass("error");
            $(this).removeClass("ok-input");

            $('#lastname-res').text('некоректне призвіще');
            $('#lastname-res').addClass('res-fail');

            lastNameCheck = false;
            checkIsAllValidated();
        } else {

            $(this).removeClass("error");
            $(this).addClass("ok-input");

            $('#lastname-res').text('✅');
            $('#lastname-res').addClass('res-succ');

            lastNameCheck = true;
            checkIsAllValidated();
        }
    });

    $('#email-input-reg').on('input',function () {
        var emailRegex = /[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/;
        if (!emailRegex.test(this.value)) {

            $(this).addClass("error");
            $(this).removeClass("ok-input");

            $('#email-res').addClass('res-fail');
            $('#email-res').text("некоректна пошта");

            emailCheck = false;
            checkIsAllValidated();
        } else {
            var email = $('#email-input-reg').val();

            $.ajax({
                url: '/Users/CheckEmail',
                type: 'GET',
                data: { email: email },
                success: function (result) {
                    if (result.exists) {
                        // email was found in the database
                        $('#email-input-reg').addClass("error");
                        $('#email-input-reg').removeClass("ok-input");

                        $('#email-res').text("пошта зайнята");
                        $('#email-res').addClass('res-fail');

                        emailCheck = false;
                        checkIsAllValidated();
                    } else {
                        $('#email-input-reg').removeClass("error");
                        $('#email-input-reg').addClass("ok-input");
                        // email was not found in the database

                        $('#email-res').text('✅');
                        $('#email-res').addClass('res-succ');

                        emailCheck = true;
                        checkIsAllValidated();
                    }
                }
            });
        }
    });

    $('#passw-input').on('input', function () {
        var passwregex = /^(?=.*[A-Z])(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?])[A-Za-z0-9!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]{8,}$/;
        if (!passwregex.test(this.value)) {

            $(this).addClass("error");
            $(this).removeClass("ok-input");

            $('#pass-res').text('слабкий пароль');
            $('#pass-res').addClass('res-fail');

            passwCheck = false;
            checkIsAllValidated();
        } else {

            $(this).removeClass("error");
            $(this).addClass("ok-input");

            $('#pass-res').text('✅');
            $('#pass-res').addClass('res-succ');

            passwCheck = true;
            checkIsAllValidated();
        }
    });

    $('#conf-pass-input').on('input', function () {

        var password = $('#passw-input').val();
        var confpassw = $('#conf-pass-input').val();
        if (password != confpassw) {

            $(this).addClass("error");
            $(this).removeClass("ok-input");

            $('#conf-pass-res').text('пароль не співпадає');
            $('#conf-pass-res').addClass('res-fail');

            passwConfCheck = false;
            checkIsAllValidated();
        } else {
            var passwregex = /^(?=.*[A-Z])(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?])[A-Za-z0-9!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]{8,}$/;

            if (!passwregex.test(this.value)) {
                $(this).addClass("error");
                $(this).removeClass("ok-input");

                $('#conf-pass-res').text('слабкий пароль');
                $('#conf-pass-res').addClass('res-fail');

                passwConfCheck = false;
                checkIsAllValidated();
            } else {
                $(this).removeClass("error");
                $(this).addClass("ok-input");

                $('#conf-pass-res').text('✅');
                $('#conf-pass-res').addClass('res-succ');

                passwConfCheck = true;
                checkIsAllValidated();
            }
        }
    });

    function checkIsAllValidated() {
        if (nameCheck && lastNameCheck && emailCheck && passwCheck && passwConfCheck && checkbox1 && checkbox2) {
            $('#register-submit').addClass('my-btn-register');
            $('#register-submit').removeClass('my-btn-register-disabled');
            console.log(checkbox1);
            console.log(checkbox2);
        } else {
            $('#register-submit').addClass('my-btn-register-disabled');
            $('#register-submit').removeClass('my-btn-register');
            console.log(checkbox1);
            console.log(checkbox2);
        }
    }

    $('#checkbox1').click(function () {
        if (this.checked) {
            checkbox1 = true;
            checkIsAllValidated();
        } else {
            checkbox1 = false;
            checkIsAllValidated();
        }
    });

    $('#checkbox2').click(function () {
        if (this.checked) {
            checkbox2 = true;
            checkIsAllValidated();
        } else {
            checkbox2 = false;
            checkIsAllValidated();
        }
    });
});


