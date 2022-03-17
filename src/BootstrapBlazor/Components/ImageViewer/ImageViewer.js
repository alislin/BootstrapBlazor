(function ($) {
    $.extend({
        bb_ImageViewer: function (el, obj, options) {
            var viewer = options.viewer;
            options.title = function (image) {
                return image.alt + ' (' + (this.index + 1) + '/' + this.length + ')';
            };
            if (undefined !== options.toolbarlite && options.toolbarlite == true) {
                options.toolbar = {
                    zoomIn: true,
                    zoomOut: true,
                    rotateRight: true,
                };
            }
            console.log('viewer0' , viewer );
           if (undefined !== viewer && null !== viewer && options.id == viewer.element.id) {
                viewer.destroy();
                console.log(viewer.element.id, 'destroy');
            }
            viewer = new Viewer(document.getElementById(options.id), options);
            console.log('viewer', viewer);
            console.log(viewer.element.id);
            return viewer;
        },
        bb_ImageViewerDestroy: function (el, obj, options) {
            var viewer = options.viewer;
           if (undefined !== viewer && null !== viewer && options.id == viewer.element.id) {
                options.viewer.destroy();
                console.log(options.viewer.element.id, 'destroy');
            }
        }
    });
})(jQuery);


