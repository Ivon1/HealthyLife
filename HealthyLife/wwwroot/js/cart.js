$(document).ready(() => {
    $.ajax({
        type: 'POST',
        url: '/UserOrders/GetStatInfo',
        data: {},
        dataType: 'json',
        success: function (result) {
            console.log(result);
            if (result.count > 0) {
                let coursesId = document.querySelectorAll('.itemCartCourseId');
                let courses1 = [];
                let courses2 = [];
                for (let c of coursesId) {
                    console.log(c.innerHTML);
                    courses1.push(parseInt(c.innerHTML));
                }
                for (let c of result.courseId) {
                    console.log(c);
                    courses2.push(c);
                }
                let intersection = courses1.filter(num => courses2.includes(num));
                console.log(intersection);
                for (let c of coursesId) {
                    if (c.innerHTML == intersection) {
                        $('.add-cart').css('display', 'none');
                        $('.del-cart').css('display', 'flex');
                    }
                    else {
                        $('.add-cart').css('display', 'flex');
                        $('.del-cart').css('display', 'none');
                    }
                }
                $('#cartItemsCount').html(result.count);
                $('#courseIdCartList').html(result.cost);
                $('#cartItemsCount').css('display', 'block');                
            }            
        }
    });

    $('#add-cart').click((event) => {
        let target = $(event.target);
        let parent = target.parent();
        let hidden = parent.find('.courseId');
        let _courseId = parseInt(hidden.val());
        alert(`Курс із ID ${_courseId} був успішно доданий до кошика`);        
        $.ajax({
            type: 'POST',
            url: '/UserOrders/AddCourseToCart',
            data: { courseId: _courseId },
            dataType: 'json',
            success: function (result) {
                console.log(result);
                $('#cartItemsCount').html(result.count);
                $('#courseIdCartList').html(result.cost);
                $('#add-cart').css('display', 'none');
                $('#del-cart').css('display', 'flex');
            }
        });
        $('#cartItemsCount').css('display', 'block');        
    });

    $('#del-cart').click((event) => {
        let target = $(event.target);
        let parent = target.parent();
        let hidden1 = parent.find('.courseId');
        let _courseId = parseInt(hidden1.val());
        alert(`Курс із ID ${_courseId} був успішно видалений із кошика`);
        $.ajax({
            type: 'POST',
            url: '/UserOrders/DeleteCourseToCart',
            data: { courseId: _courseId },
            dataType: 'json',
            success: function (result) {
                console.log(result);
                $('#cartItemsCount').html(result.count);
                $('#courseIdCartList').html(result.courseId);
                $('#del-cart').css('display', 'none');
                $('#add-cart').css('display', 'flex');
                if (result.count > 0) {
                    $('#cartItemsCount').css('display', 'block');
                }
                else {
                    $('#cartItemsCount').css('display', 'none');
                }
            }
        });
    });

    $('.del-item-in-cart').hover(function () {
        $(this).attr("src", "/img/icons/del-item-cart-active.png");        
    }, function () {
        $(this).attr("src", "/img/icons/del-item-cart.png");
    });
});