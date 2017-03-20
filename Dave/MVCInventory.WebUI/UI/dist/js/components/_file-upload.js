// Enable file upload input label to recognize input pseudo state

$('label.type-file').on('focus blur', 'label.type-file > input', function() {
    var elem = $(this);
    setTimeout(function() {
    elem.toggleClass('hasFocus', elem.is(':focus'));
    elem.toggleClass('isInvalid', elem.is(':invalid'));
    },0);
});

// Display filename for file upload input elements
$('label.type-file > input').change(function() {
    var numFiles = $(this)[0].files.length;
    var filename = $(this).val().split('\\').pop();
    if(numFiles > 0) {
        $(this).parent().addClass('hasValue');
    }
    if(numFiles > 1) { 
        $(this).siblings('.span-filename').text(numFiles + " files selected");
    }
    else {
        $(this).siblings('.span-filename').text(filename);
    }
}).change();