import '/_content/BootstrapBlazor/lib/viewerjs/js/viewer.min.js';
var viewer = null;
export function initOptions(options) {
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
    if (undefined !== viewer && null !== viewer && options.id == viewer.element.id) {
        viewer.destroy();
        console.log(viewer.element.id, 'destroy');
    }
    viewer = new Viewer(document.getElementById(options.id), options);
    console.log(viewer.element.id);
}
export function destroy(options) {
    if (undefined !== viewer && null !== viewer && options.id == viewer.element.id) {
        viewer.destroy();
        console.log(viewer.element.id, 'destroy');
    }
}
