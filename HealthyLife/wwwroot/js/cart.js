$(document).ready(() => {
    $('#cartItemsCount').css('display', 'block');
    $('#cost').css('display', 'block');
    $.ajax({
        type: 'POST',
        url: '/UserOrders/GetStatInfo',
        data: {},
        dataType: 'json',
        success: function (result) {
            console.log(result);
            $('#cartItemsCount').html(result.count);
            $('#cost').html(result.cost);
        }
    });

    $('.add-cart').click((event) => {
        let target = $(event.target);
        let parent = target.parent();
        let hidden = parent.find('.courseId');
        let _courseId = parseInt(hidden.val());
        alert(`Товар із ID ${_courseId} був успішно доданий`);
        $('#cartItemsCount').css('display', 'block');
        $('#cost').css('display', 'block');
        $.ajax({
            type: 'POST',
            url: '/UserOrders/AddCourseToCart',
            data: { courseId: _courseId },
            dataType: 'json',
            success: function (result) {
                console.log(result);
                $('#cartItemsCount').html(result.count);
                $('#cost').html(result.cost);
            }
        });
    });
});