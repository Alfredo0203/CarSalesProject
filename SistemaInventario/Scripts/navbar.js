
/*:::::::::::::::::::::NAVBAR HOVER DESPLEGAR::::::::::::::::::::::::::*/
(function ($) {
    "use strict";

    //Menu On Hover
    $('body').on('mouseenter mouseleave', '.nav-item', function (e) {
        if ($(window).width() > 750) {
            var _d = $(e.target).closest('.nav-item');
            _d.addClass('show');
            setTimeout(function () {
                _d[_d.is(':hover') ? 'addClass' : 'removeClass']('show');
            }, 1);
        }
    });

})(jQuery);