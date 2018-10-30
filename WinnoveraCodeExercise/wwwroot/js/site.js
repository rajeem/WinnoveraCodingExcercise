// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function toggleShow(sender) {
    $(sender).closest('div').find('.job-body').toggle();
    $(sender).toggleClass('glyphicon-chevron-right');
    $(sender).toggleClass('glyphicon-chevron-down');
}

$(function () {
    $.ajax({
        type: 'GET',
        url: '/api/jobs',
        success: function (res) {
            if (res) {
                for (var i = 0; i < res.length; i++) {
                    $('#content').append('<div><p class="job-title glyphicon glyphicon-chevron-right" onclick="toggleShow(this)">' + res[i].title + '</p><div class="job-body" style="display:none">' + res[i].description + '</div></div>');
                }
            }
        }
    })
})