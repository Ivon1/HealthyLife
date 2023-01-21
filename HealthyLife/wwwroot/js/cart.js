$(document).ready(() => {
    $.ajax({
        type: 'POST',
        url: '/UserOrders/GetStatInfo',
        data: {},
        dataType: 'json',
        success: function (result) {
            console.log(result);
            if (result.count > 0) {
                $('#cartItemsCount').html(result.count);
                $('#cost').html(result.cost);
                $('#cartItemsCount').css('display', 'block');                
            }            
        }
    });

    $('.add-cart').click((event) => {
        let target = $(event.target);
        let parent = target.parent();
        let hidden = parent.find('.courseId');
        let _courseId = parseInt(hidden.val());
        alert(`Товар із ID ${_courseId} був успішно доданий`);        
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
        $('#cartItemsCount').css('display', 'block');        
    });

    $('.del-item-in-cart').hover(function () {
        $(this).attr("src", "/img/icons/del-item-cart-active.png");        
    }, function () {
        $(this).attr("src", "/img/icons/del-item-cart.png");
    });
});