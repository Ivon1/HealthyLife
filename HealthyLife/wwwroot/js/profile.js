$(document).ready(function () {

    var statusEdit = false;
    var statusSettings = false;
    
    $('#edit-btn').click(function () {
        if (!statusEdit) {
            $('#setting').hide();
            $('#calendar').hide();
            $('#rating').hide();
            $('#saveBtn').show();
            $('#cancelBtn').show();
            $(this).css('margin-top', '30px');

            $('.received-certificates').prop('disabled', true);
            $('.received-certificates').css('opacity', 0.5);

            $('#row1').prop('disabled', true);
            $('#row1').css('opacity', 0.5);
            $('#row2').prop('disabled', true);
            $('#row2').css('opacity', 0.5);

            $('#roles-list').show();
            $('#current-role').hide();

            $("#img-profile").hide();
            $("#img-edit-profile").show();
            
            $('#navigation-container').hide();
            statusEdit = true;
        }
        else {
            $('#setting').show();
            $('#calendar').show();
            $('#rating').show();
            $('#saveBtn').hide();
            $('#cancelBtn').hide();
            $(this).css('margin-top', '11px');

            $('.received-certificates').prop('disabled', false);
            $('.received-certificates').css('opacity', 1);

            $('#row1').prop('disabled', false);
            $('#row1').css('opacity', 1);
            $('#row2').prop('disabled', false);
            $('#row2').css('opacity', 1);

            $('#roles-list').hide();
            $('#current-role').show();

            $("#img-profile").show();
            $("#img-edit-profile").hide();


            $('#navigation-container').show();
            statusEdit = false;
        }
    });

    $('#cancelBtn').click(function () {
        $('#edit-btn').click();
    });

    $('#saveBtn').click(function () {
        var userId = $('#userId').val();
        var newRoleName = $('#roles-list').val();
        alert(userId);
        alert(newRoleName);

        $.ajax({
            type: 'POST',
            url: '/Roles/AssignAjax',
            data: { userId: userId, roleName: newRoleName },
            success: function (data) {
                if (data.success) {
                    console.log(data);
                    alert("Роль изменена успешно!");
                } else {
                    console.log(data);
                    alert("Произошла ошибка при изменении роли");
                }
            }
        });
    });

    $('#setting').click(function () {
        window.location.href = '/Identity/Account/Settings';
    });

    $('#back-btn').click(function () {
        window.location.href = '/Identity/Account/Manage/CurrentCourses';
    });

    $("#img-edit-profile").click(function () {
        window.location.href = '/Identity/Account/Settings/ChangePhoto';
    });
});