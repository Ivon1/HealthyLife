$(document).ready(() => {
    
    /*$('.add-wishlist').hover(function () {
        $('.heart_image').attr("src", "/img/icons/heart_purpur.png");
        $('.add-wishlist').css("background-color", "silver");
    }, function () {
        $('.heart_image').attr("src", "/img/icons/hear_ico.png");
        $('.add-wishlist').css("background-color", "white");
    });

    $('.del-wishlist').hover(function () {
        $('.heart_image').attr("src", "/img/icons/hear_ico.png");
        $('.del-wishlist').css("background-color", "white");
    }, function () {
        $('.heart_image').attr("src", "/img/icons/heart_purpur.png");
        $('.del-wishlist').css("background-color", "silver");
    });*/

    $.ajax({
        type: 'POST',
        url: '/UserWishes/GetStatInfo',
        data: {},
        dataType: 'json',
        success: function (result) {
            console.log(result);
            if (result.count > 0) {
                let coursesId = document.querySelectorAll('.itemCourseId');
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
                        $('.add-wishlist').css('display', 'none');
                        $('.del-wishlist').css('display', 'flex');
                    }
                    else {
                        $('.add-wishlist').css('display', 'flex');
                        $('.del-wishlist').css('display', 'none');
                    }
                }
                /*$('.add-wishlist').each((event) => {
                    let target = $(event.target);
                    let parent = target.parent();
                    let hidden1 = parent.find('.itemCourseId');
                    let _courseId = parseInt(hidden1.val());
                    if (_courseId == intersection) {
                        console.log(_courseId);
                        $('.add-wishlist').css('display', 'none');
                        $('.del-wishlist').css('display', 'flex');
                    }
                    else {
                        $('.add-wishlist').css('display', 'flex');
                        $('.del-wishlist').css('display', 'none');
                    }
                });*/
                
                $('#wishlistCount').html(result.count);
                $('#courseIdList').html(result.courseId);
                $('#wishlistCount').css('display', 'block');                
            }
        }
    });
   
    $('#add-wishlist').click((event) => {
        let target = $(event.target);
        let parent = target.parent();
        let hidden1 = parent.find('.courseId');        
        let _courseId = parseInt(hidden1.val());                
        alert(`Курс із ID ${_courseId} був успішно доданий до списку бажань`);
        $.ajax({
            type: 'POST',
            url: '/UserWishes/AddCourseToWishlist',
            data: { courseId: _courseId },
            dataType: 'json',
            success: function (result) {
                console.log(result);
                $('#wishlistCount').html(result.count);
                $('#courseIdList').html(result.courseId);
                $('#add-wishlist').css('display', 'none');
                $('#del-wishlist').css('display', 'flex');
            }
        });        
        console.log(_courseId);
        $('#wishlistCount').css('display', 'block');        
        
    });

    $('#del-wishlist').click((event) => {
        let target = $(event.target);
        let parent = target.parent();
        let hidden1 = parent.find('.courseId');        
        let _courseId = parseInt(hidden1.val());        
        alert(`Курс із ID ${_courseId} був успішно видалений із списку бажань`);
        $.ajax({
            type: 'POST',
            url: '/UserWishes/DeleteCourseToWishlist',
            data: { courseId: _courseId },
            dataType: 'json',
            success: function (result) {
                console.log(result);
                $('#wishlistCount').html(result.count);
                $('#courseIdList').html(result.courseId);
                $('#del-wishlist').css('display', 'none');
                $('#add-wishlist').css('display', 'flex');
                if (result.count > 0) {
                    $('#wishlistCount').css('display', 'block');                    
                }
                else {
                    $('#wishlistCount').css('display', 'none');                    
                }
            }
        });
    });
});