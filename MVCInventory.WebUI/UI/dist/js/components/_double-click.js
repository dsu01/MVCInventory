// Stop double-clicks

$('.button').on('dblclick', function(e) { 
    e.preventDefault();
});

$('a').on('dblclick', function(e) { 
    e.preventDefault();
});