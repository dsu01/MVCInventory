// Set background color for current top navigation tabs (icon-bar)

var currentID = $('#appContent').attr('ng-app');
if (currentID !== undefined) {
    // var currentID = $('main').attr('id');
    $('.top-bar .icon-bar .item').each(function() {
        if($(this).attr('id') == currentID) {
            $(this).addClass('current');
        }
        else {
            $(this).removeClass('current');
        }
    });

    if($('.top-bar .icon-bar .item').attr('id')) {
        $(this).toggleClass('current');
    };
};