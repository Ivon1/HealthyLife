$(document).ready(() => {
    $('.add-wishlist').hover(function () {
        $('.heart_image').attr("src", "/img/icons/heart_purpur.png");
    }, function () {
        $('.heart_image').attr("src", "/img/icons/hear_ico.png");
    });

    $.ajax({
        type: 'POST',
        url: '/UserWishes/GetStatInfo',
        data: {},
        dataType: 'json',
        success: function (result) {
            console.log(result);
            if (result.count > 0) {
                $('#wishlistCount').html(result.count);                
                $('#wishlistCount').css('display', 'block');                
            }
        }
    });

    let flag = 1;
    $('.add-wishlist').click((event) => {
        if (flag == 1) {
            let target = $(event.target);
            let parent = target.parent();
            let hidden = parent.find('.courseId');
            let _courseId = parseInt(hidden.val());
            alert(`Товар із ID ${_courseId} був успішно доданий до списку бажань`);
            $.ajax({
                type: 'POST',
                url: '/UserWishes/AddCourseToWishlist',
                data: { courseId: _courseId },
                dataType: 'json',
                success: function (result) {
                    console.log(result);
                    $('#wishlistCount').html(result.count);
                }
            });
            $('#wishlistCount').css('display', 'block');
            $('.heart_image').attr("src", "/img/icons/heart_purpur.png");
            flag = 2;
            console.log("First");
        } else {
            let target = $(event.target);
            let parent = target.parent();
            let hidden = parent.find('.courseId');
            let _courseId = parseInt(hidden.val());
            alert(`Товар із ID ${_courseId} був успішно видалений із списку бажань`);
            $.ajax({
                type: 'POST',
                url: '/UserWishes/DeleteCourseToWishlist',
                data: { courseId: _courseId },
                dataType: 'json',
                success: function (result) {
                    console.log(result);
                    $('#wishlistCount').html(result.count);
                }
            });
            $('#wishlistCount').css('display', 'block');
            $('.heart_image').attr("src", "/img/icons/hear_ico.png");
            flag = 1;
            console.log("Second");
        }
              
    });   
});