$(document).ready(function () {
    // NEVER CACHE AJAX REQUESTS
    $.ajaxSetup({
        cache: false
    });



    // HANDLE TRANSPERACY FOR MOUSEENTER STEP WRAPPER
    $('.layout_stepWrapperActive, .step_icon').mouseenter(function () {
        $(this).animate({ opacity: 0.7 }, 100);
    });


    // HANDLE TRANSPERACY FOR MOUSELEAVE STEP WRAPPER	
    $('.layout_stepWrapperActive, .step_icon').mouseleave(function () {
        $(this).animate({ opacity: 1 }, 100);
    });


    // HANDLE CLICKING OVER STEP WRAPPER
    $('.layout_stepWrapperActive').click(function () {
        window.location = $(this).attr("data-url");
    });

});