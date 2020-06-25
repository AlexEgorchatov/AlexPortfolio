﻿$('#save-link').on('click', () => {
    var contactContentViewModel = {
        HeaderText: $('#contact-header-text-input').val(),
        Phone: $('#contact-phone-input').val(),
        Email: $('#contact-email-input').val(),
    };

    $.ajax({
        type: "POST",
        url: "/Home/UpdateContact",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ contactContent: contactContentViewModel }),
        success: (data) => {
            if (data == "") {
                $('#signup-modal').modal('show');
            } else {
                var object = JSON.parse(data);
                if (object.result == "success") {
                    $('#contact-header-text').text(object.headerText);
                    $('#contact-phone').text(object.phone);
                    $('#contact-email').text(object.email);
                    $('#contact-header-text-editor').collapse('hide');
                    $('#contact-body-editor').collapse('hide');
                } else {
                    $('#error-text').text(object.error);
                    $('#error-modal').modal('show');
                }
            }
        },
        error: (jqXhr, status, error) => {
            var error = "jqXhr status: " + jqXhr.status + " jqXhr status text: " + jqXhr.statusText + " | status: " + status + " | error: " + error;
            $('#error-text').text(error);
            $('#error-modal').modal('show');
        }
    });
});

$('#contact-send-email').on('click', () => {
    var $form = $('#contact-email-form');
    if ($form.get(0).checkValidity()) {

        var sendEmailViewModel = {
            Sender: $('#contact-sender-email').val(),
            Subject: $('#contact-subject').val(),
            Message: $('#contact-type-message').val()
        };

        $.ajax({
            type: "POST",
            url: "SendEmail",
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ email: sendEmailViewModel }),
            success: (data) => {
                if (data == "") {
                    $('#signup-modal').modal('show');
                } else {
                    var object = JSON.parse(data);
                    if (object.result == "success") {

                    } else {

                    }
                }
                error: (jqXhr, status, error) => {
                    var error = "jqXhr status: " + jqXhr.status + " jqXhr status text: " + jqXhr.statusText + " | status: " + status + " | error: " + error;
                    $('#error-text').text(error);
                    $('#error-modal').modal('show');
                }
            }
        });
    } else {
        if (!$('#contact-sender-email').val()) {
            $('#contact-sender-email').addClass('is-invalid');
        }
    }
});

$('.editor-collapse').on('hidden.bs.collapse', function () {
    $('#contact-header-text-input').val('');
    $('#contact-phone-input').val('');
    $('#contact-email-input').val('');
});

$('.editor-collapse').on('show.bs.collapse', function () {
    $('#contact-header-text-input').val($('#contact-header-text').text());
    $('#contact-phone-input').val($('#contact-phone').text());
    $('#contact-email-input').val($('#contact-email').text());
});
