(function ($) {
    $.extend({
        bb_showLabelTooltip: function (el, title) {
            var $el = $(el);
            $el.tooltip({
                title
            });
        }
    });
}(jQuery));
