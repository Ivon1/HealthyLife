function hover(element) {
    element.setAttribute('src', '../img/icons/hovered_heard.png');
}

function unhover(element) {
    element.setAttribute('src', '../img/icons/hear_ico.png');
}

$(document).ready(function () {
    getLocalDisplay();

    $('#media').carousel({
        pause: true,
        interval: false,
    });

    $('.btn').on('mousedown', function () {
        $(this).removeClass('hover');
    });

    var innerWidth = $(document).width();
    var swiper;
    var swiper1;
    var swiper2;

    if (innerWidth <= 950) {

        swiper = new Swiper(".mySwiper", {
            slidesPerView: 1,
            spaceBetween: 3,
            slidesPerGroup: 1,
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

        swiper1 = new Swiper(".mySwiper1", {
            slidesPerView: 1,
            spaceBetween: 3,
            slidesPerGroup: 1,
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

        swiper2 = new Swiper(".mySwiper2", {
            slidesPerView: 1,
            spaceBetween: 3,
            slidesPerGroup: 1,
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

        $('.product-card').css('width', '257.34px');
        $('.courseDescriptionShortFont').css('font-size', '20px');
        $('.priceItem').css('width', '112px');
        $('.detailPrice').css('font-size', '25px');
        $('.detailPrice').css('top', '5px');
        $('.detailItem').css('width', '112px');
        $('.detailFont').css('font-size', '25px');
        $('.detailFont').css('top', '5px');
    } else if (innerWidth <= 1399) {

        swiper = new Swiper(".mySwiper", {
            slidesPerView: 2,
            spaceBetween: 15,
            slidesPerGroup: 2,
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

        swiper1 = new Swiper(".mySwiper1", {
            slidesPerView: 2,
            spaceBetween: 5,
            slidesPerGroup: 2,
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

        swiper2 = new Swiper(".mySwiper2", {
            slidesPerView: 1,
            spaceBetween: 5,
            slidesPerGroup: 1,
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
    }
    else if (innerWidth >= 1420)
    {

        swiper = new Swiper(".mySwiper", {
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

        swiper1 = new Swiper(".mySwiper1", {
            slidesPerView: 3,
            spaceBetween: 10,
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

        swiper2 = new Swiper(".mySwiper2", {
            slidesPerView: 3,
            spaceBetween: 10,
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
    }

    $(window).resize(function () {
        innerWidth = $(document).width();


        if (innerWidth <= 950) {

            swiper.params.slidesPerView = 1;
            swiper.params.spaceBetween = 3;
            swiper.params.slidesPerGroup = 1;
            swiper.update();

            swiper1.params.slidesPerView = 1;
            swiper1.params.spaceBetween = 3;
            swiper1.params.slidesPerGroup = 1;
            swiper1.update();

            swiper2.params.slidesPerView = 1;
            swiper2.params.spaceBetween = 3;
            swiper2.params.slidesPerGroup = 1;
            swiper2.update();

            $('.product-card').css('width', '257.34px');
            $('.courseDescriptionShortFont').css('font-size', '20px');
            $('.priceItem').css('width', '112px');
            $('.detailPrice').css('font-size', '25px');
            $('.detailPrice').css('top', '5px');
            $('.detailItem').css('width', '112px');
            $('.detailFont').css('font-size', '25px');
            $('.detailFont').css('top', '5px');
        }
        else if (innerWidth <= 1399) {
            $('.product-card').css('width', '391px');
            $('.courseDescriptionShortFont').css('font-size', '30px');
            $('.priceItem').css('width', '112px');
            $('.detailPrice').css('font-size', '25px');
            $('.detailPrice').css('top', '5px');
            $('.detailItem').css('width', '112px');
            $('.detailFont').css('font-size', '25px');
            $('.detailFont').css('top', '5px');

            swiper.params.slidesPerView = 2;
            swiper.params.spaceBetween = 3;
            swiper.params.slidesPerGroup = 2;
            swiper.update();

            swiper1.params.slidesPerView = 2;
            swiper1.params.spaceBetween = 5;
            swiper1.params.slidesPerGroup = 2;
            swiper1.update();

            swiper2.params.slidesPerView = 2;
            swiper2.params.spaceBetween = 5;
            swiper2.params.slidesPerGroup = 2;
            swiper2.update();
        }
        else if (innerWidth >= 1420) {

            swiper.params.slidesPerView = 3;
            swiper.params.spaceBetween = 3;
            swiper.params.slidesPerGroup = 3;
            swiper.update();

            swiper1.params.slidesPerView = 3;
            swiper1.params.spaceBetween = 10;
            swiper1.params.slidesPerGroup = 3;
            swiper1.update();

            swiper2.params.slidesPerView = 3;
            swiper2.params.spaceBetween = 10;
            swiper2.params.slidesPerGroup = 3;
            swiper2.update();

            $('.product-card').css('width', '391px');
            $('.courseDescriptionShortFont').css('font-size', '30px');
            $('.priceItem').css('width', '112px');
            $('.detailPrice').css('font-size', '25px');
            $('.detailPrice').css('top', '5px');
            $('.detailItem').css('width', '112px');
            $('.detailFont').css('font-size', '25px');
            $('.detailFont').css('top', '5px');
        }
    });

    //swiper = new Swiper(".mySwiper", {
    //    slidesPerView: 3,
    //    spaceBetween: 20,
    //    slidesPerGroup: 3,
    //    loop: true,
    //    loopFillGroupWithBlank: true,
    //    pagination: {
    //        el: ".swiper-pagination",
    //        clickable: true,
    //    },
    //    navigation: {
    //        nextEl: ".swiper-button-next",
    //        prevEl: ".swiper-button-prev",
    //    },
    //});

    //swiper1 = new Swiper(".mySwiper1", {
    //    slidesPerView: 3,
    //    spaceBetween: 20,
    //    slidesPerGroup: 3,
    //    loop: true,
    //    loopFillGroupWithBlank: true,
    //    pagination: {
    //        el: ".swiper-pagination1",
    //        clickable: true,
    //    },
    //    navigation: {
    //        nextEl: ".swiper-button-next1",
    //        prevEl: ".swiper-button-prev1",
    //    },
    //});

    //swiper2 = new Swiper(".mySwiper2", {
    //    slidesPerView: 3,
    //    spaceBetween: 20,
    //    slidesPerGroup: 3,
    //    loop: true,
    //    loopFillGroupWithBlank: true,
    //    pagination: {
    //        el: ".swiper-pagination2",
    //        clickable: true,
    //    },
    //    navigation: {
    //        nextEl: ".swiper-button-next2",
    //        prevEl: ".swiper-button-prev2",
    //    },
    //});

    $('#list').click(function () {
        list();
        saveLocalDisplay('list');
    });

    $('#grid3').click(function () {
        grid3();
        saveLocalDisplay('grid3');
    });

    $('#grid4').click(function () {
        grid4();
        saveLocalDisplay('grid4');
    });

    $('#grid5').click(function () {
        grid5();
        saveLocalDisplay('grid5');
    });

    function list() {
        $('.list-image').attr('src', '/img/icons/list-active.png');
        $('.grid3-image').attr('src', '/img/icons/grid3.png');
        $('.grid4-image').attr('src', '/img/icons/grid4.png');
        $('.grid5-image').attr('src', '/img/icons/grid5.png');
        $('.list-div').css('display', 'inline');
        $('.grid-div').css('display', 'none');
    }

    function grid3() {
        $('.list-image').attr('src', '/img/icons/list.png');
        $('.grid3-image').attr('src', '/img/icons/grid3-active.png');
        $('.grid4-image').attr('src', '/img/icons/grid4.png');
        $('.grid5-image').attr('src', '/img/icons/grid5.png');
        $('.list-div').css('display', 'none');
        $('.grid-div').css('display', 'flex');
        $('.courseDescriptionShortFont').css('font-size', '30px');
        $('.priceItem').css('width', '112px');
        $('.detailPrice').css('font-size', '25px');
        $('.detailPrice').css('top', '5px');
        $('.detailItem').css('width', '112px');
        $('.detailFont').css('font-size', '25px');
        $('.detailFont').css('top', '5px');
        $('.course').each(function () {
            $(this).removeClass('grid4');
            $(this).removeClass('grid5');
            $(this).addClass('grid3');
        });
    }

    function grid4() {
        $('.list-image').attr('src', '/img/icons/list.png');
        $('.grid3-image').attr('src', '/img/icons/grid3.png');
        $('.grid4-image').attr('src', '/img/icons/grid4-active.png');
        $('.grid5-image').attr('src', '/img/icons/grid5.png');
        $('.list-div').css('display', 'none');
        $('.grid-div').css('display', 'flex');
        $('.courseDescriptionShortFont').css('font-size', '26px');
        $('.priceItem').css('width', '97px');
        $('.detailPrice').css('font-size', '21px');
        $('.detailPrice').css('top', '8px');
        $('.detailItem').css('width', '97px');
        $('.detailFont').css('font-size', '21px');
        $('.detailFont').css('top', '8px');
        $('.course').each(function () {
            $(this).removeClass('grid3');
            $(this).removeClass('grid5');
            $(this).addClass('grid4');
        });
    }

    function grid5() {
        $('.list-image').attr('src', '/img/icons/list.png');
        $('.grid3-image').attr('src', '/img/icons/grid3.png');
        $('.grid4-image').attr('src', '/img/icons/grid4.png');
        $('.grid5-image').attr('src', '/img/icons/grid5-active.png');
        $('.list-div').css('display', 'none');
        $('.grid-div').css('display', 'flex');
        $('.courseDescriptionShortFont').css('font-size', '22px');
        $('.courseDescriptionShortFont').css('padding-top', '10%');
        $('.priceItem').css('width', '82px');
        $('.detailPrice').css('font-size', '18px');
        $('.detailPrice').css('top', '10px');
        $('.detailItem').css('width', '82px');
        $('.detailFont').css('font-size', '18px');
        $('.detailFont').css('top', '10px');
        $('.course').each(function () {
            $(this).removeClass('grid3');
            $(this).removeClass('grid4');
            $(this).addClass('grid5');
        });
    }

    function saveLocalDisplay(display) {
        let displays;
        if (localStorage.getItem('displays') === null) {
            displays = ['grid3'];
        } else {
            displays = JSON.parse(localStorage.getItem('displays'));
        }
        displays.push(display);
        localStorage.setItem('displays', JSON.stringify(displays));
    }

    function getLocalDisplay() {
        let displays;
        if (localStorage.getItem('displays') === null) {
            displays = ['grid3'];
        } else {
            displays = JSON.parse(localStorage.getItem('displays'));
        }
        if (displays[displays.length - 1] == 'grid3') {
            grid3();
        }
        if (displays[displays.length - 1] == 'grid4') {
            grid4();
        }
        if (displays[displays.length - 1] == 'grid5') {
            grid5();
        }
        if (displays[displays.length - 1] == 'list') {
            list();
        }
    }

    let flag = 1;
    $(document).mouseup(function (e) {
        var container = $(".subject-list");
        var container3 = $(".author-list");
        if (container.has(e.target).length === 0) {
            container.hide();
            flag = 1;
            $('.arrow').css('color', '#808080');
        }
        if (container3.has(e.target).length === 0) {
            container3.hide();
            flag = 1;
            $('.arrow3').css('color', '#808080');
        }
    });
    
    $('#choiceSubject').click(function () {
        if (flag == 1) {            
            $('.subject-list').css('display', 'flex');
            $('.arrow').css('color', '#F25564');
            flag = 2;
        }        
    }); 

    $('#choiceAuthor').click(function () {
        if (flag == 1) {
            $('.author-list').css('display', 'flex');
            $('.arrow3').css('color', '#F25564');
            flag = 2;
        }
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


