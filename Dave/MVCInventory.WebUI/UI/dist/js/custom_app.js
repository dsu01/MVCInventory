$(document).foundation('reflow');

(function($) {

	$(document).ready(function() {
        
        // Enable sticky navigation bar
        $("header").headroom({
          "offset": 110,
          "tolerance": 5,
          "classes": {
            "initial": "headroom",
            "pinned": "headroom--pinned",
            "unpinned": "headroom--unpinned",
            "top": "headroom--top",
            "notTop": "headroom--not-top"
          }
        });
        
        // Full Calendar
        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,basicWeek'
            },
            buttonIcons: 'false',
            eventLimit: 6
            
        });

        // to destroy
        $("header").headroom("destroy");
        
        /* Set top-margin for <main> so content is not blocked by <header>
        var headerHeight = $('header').outerHeight();
        if($('body').hasClass('f-topbar-fixed')) {
            var mainTop = headerHeight + 24 + "px";
            $('main').css('paddingTop',mainTop);
            $('#appContent').css('paddingTop',mainTop);
        };
        */
        
        // Enable <textarea> to grow in size with content
        // $('textarea').textareaAutoSize();

	    /* Activate Footable Tables
        
        IMPLEMENTED IN SOURCE SCRIPT BC OF ANGULAR DIRECTIVE
        
	    $('.footable').footable({
            breakpoints: {
                phone: 420,
                phablet: 680,
                tablet: 900
            }
        });
        */
        
        // Add classes to document to indicate modal state -- NOT WORKING!!!
        $('.reveal-modal').on('open.fndtn.reveal', '[data-reveal]', function () {
            $('html').addClass('modal-open');
        });
        $('.reveal-modal').on('close.fndtn.reveal', '[data-reveal]', function () {
            $('html').removeClass('modal-open');
        });

	});

})(jQuery);