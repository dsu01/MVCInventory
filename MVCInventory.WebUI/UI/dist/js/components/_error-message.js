// Style validation error messages

$('.validation-summary-errors').each(function () {
    $(this).addClass('alert-box alert small-centered').data('data-alert');
    $(this).find('li:only-child').parent().css('list-style','none').css('margin-left',0);
});