$(document).ready(function () {
    var nameCheck = false;
    var lastNameCheck = false;
    var phoneCheck = false;
    var emailCheck = false;

    if ($('#name-input').val() === '') {
        $('#name-edit-status').show();
    } else {
        nameCheck = true;
    }

    if ($('#lastname-input').val() === '') {
        $('#lastname-edit-status').show();
    } else {
        lastNameCheck = true;
    }

    if ($('#phone-input').val() === '') {
        $('#phone-edit-status').show();
    } else {
        phoneCheck = true;
    }

    if ($('#email-input').val() === '') {
        $('#email-edit-status').show();
    } else {
        emailCheck = true;
    }

    console.log(nameCheck);
    console.log(lastNameCheck);
    console.log(phoneCheck);
    console.log(emailCheck);

    $('#name-input').on('input', function () {
        var nameregex = /[a-zA-Zа-яА-Яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ]$/;
        if (!nameregex.test(this.value)) {

            $('#name-edit-status').show();

            $('#name-edit-status').text('некоректне ім’я');
            $('#name-edit-status').addClass('res-fail');

            nameCheck = false;
            checkIsAllValidated();
        } else {
            $('#name-edit-status').show();

            $('#name-edit-status').text('✅');
            $('#name-edit-status').addClass('res-succ');

            nameCheck = true;
            checkIsAllValidated();
        }
    });

    $('#lastname-input').on('input', function () {
        var nameregex = /[a-zA-Zа-яА-Яа-щА-ЩЬьЮюЯяЇїІіЄєҐґ]$/;
        if (!nameregex.test(this.value)) {
            $('#lastname-edit-status').show();

            $('#lastname-edit-status').text('некоректне призвіще');
            $('#lastname-edit-status').addClass('res-fail');

            lastNameCheck = false;
            checkIsAllValidated();
        } else {
            $('#lastname-edit-status').show();

            $('#lastname-edit-status').text('✅');
            $('#lastname-edit-status').addClass('res-succ');

            lastNameCheck = true;
            checkIsAllValidated();
        }
    });

    $('#phone-input').on('input', function () {
        var nameregex = /^[\+]?3?[\s]?8?[\s]?\(?0\d{2}?\)?[\s]?\d{3}[\s|-]?\d{2}[\s|-]?\d{2}$/;
        if (!nameregex.test(this.value)) {
            $('#phone-edit-status').show();

            $('#phone-edit-status').text('некоректний телефон');
            $('#phone-edit-status').addClass('res-fail');

            phoneCheck = false;
            checkIsAllValidated();
        } else {
            $('#phone-edit-status').show();

            $('#phone-edit-status').text('✅');
            $('#phone-edit-status').addClass('res-succ');

            phoneCheck = true;
            checkIsAllValidated();
        }
    });

    $('#email-input').on('input', function () {
        var emailRegex = /[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,}$/;
        if (!emailRegex.test(this.value)) {
            $('#email-edit-status').show();

            $('#email-edit-status').addClass('res-fail');
            $('#email-edit-status').text("некоректна пошта");

            emailCheck = false;
            checkIsAllValidated();
        } else {
            $('#email-edit-status').show();
            var email = $('#email-input').val();

            $.ajax({
                url: '/Users/CheckEmailInEditing',
                type: 'GET',
                data: { email: email },
                success: function (result) {
                    if (result.exists) {
                        // email was found in the database
                        $('#email-edit-status').text("пошта зайнята");
                        $('#email-edit-status').addClass('res-fail');

                        emailCheck = false;
                        checkIsAllValidated();
                    } else {
                        // email was not found in the database

                        $('#email-edit-status').text('✅');
                        $('#email-edit-status').addClass('res-succ');

                        emailCheck = true;
                        checkIsAllValidated();
                    }
                }
            });
        }
    });

    function checkIsAllValidated() {
        if (nameCheck && lastNameCheck && emailCheck && phoneCheck) {
            $('#submit-btn').addClass('save-btn');
            $('#submit-btn').removeClass('save-btn-disabled');
        } else {
            $('#submit-btn').addClass('save-btn-disabled');
            $('#submit-btn').removeClass('save-btn');
        }
    }
});