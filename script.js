//------------TOASTR-------------//

function toastify(type, msg, title, position, showclosebutton) {
    if (position == null || position == '') {
        toastr.options.positionClass = 'toast-bottom-right';
    }
    else {
        toastr.options.positionClass = position;
    }
    if (showclosebutton == null || showclosebutton == '' || showclosebutton == 'true') {
        toastr.options.closeButton = true;
    }
    else {
        toastr.options.closeButton = false;
    }
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "10000",
        "hideDuration": "1000",
        "timeOut": "10000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    switch (type) {
        case 'success': toastr.success(msg, title);
            break;
        case 'info': toastr.info(msg, title);
            break;
        case 'warning': toastr.warning(msg, title);
            break;
        case 'error': toastr.error(msg, title);
            break;
    }
    //toastr.clear();
}