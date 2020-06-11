// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

$(function () {
    const modalHandler = function modalHandler() {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            // append HTML to document, find modal and show it
            $('#modal-placeholder').html(data);
            $(document).find('.modal').modal('show');
        });
    }

    const nextMonthBtnHandler = function nextMonthBtnHandler() {
        // url to Razor Pages handler which returns calendar HTML
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            // replace current calendar with new one
            $('.calendar').html(data);
            // pin events after replacing html code
            $('a[data-toggle="ajax-modal"]').click(modalHandler);
            $('a[data-toggle="video-modal"]').click(modalHandler);
            $('button[data-toggle="next-month"]').click(nextMonthBtnHandler);
            $('button[data-toggle="prev-month"]').click(previousMonthBtnHandler);
        });
    }

    const previousMonthBtnHandler = function previousMonthBtnHandler() {
        // url to Razor Pages handler which returns calendar HTML
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            // replace current calendar with new one
            $('.calendar').html(data);
            // pin events after replacing html code
            $('a[data-toggle="ajax-modal"]').click(modalHandler);
            $('a[data-toggle="video-modal"]').click(modalHandler);
            $('button[data-toggle="next-month"]').click(nextMonthBtnHandler);
            $('button[data-toggle="prev-month"]').click(previousMonthBtnHandler);
        });
    }

    $('a[data-toggle="ajax-modal"]').click(modalHandler);
    $('a[data-toggle="video-modal"]').click(modalHandler);
    $('button[data-toggle="next-month"]').click(nextMonthBtnHandler);
    $('button[data-toggle="prev-month"]').click(previousMonthBtnHandler);
});