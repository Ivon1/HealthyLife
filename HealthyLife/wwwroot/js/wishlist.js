$(document).ready(() => {
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

    $('.add-wishlist').click((event) => {
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
    });
});