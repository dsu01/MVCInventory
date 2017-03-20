// Provide class for inputs that have a value in the DOM
$('input').change(function() {
    var inputValue = $(this).val();
    if(inputValue.length > 0) {
        $(this).addClass('hasValue');
    }
    else {
        $(this).removeClass('hasValue');  
    }
}).change();

