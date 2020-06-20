$('#home-edit-save').on('click', () => {
    var homeContentViewModel = {
        Greeting: $('#home-greeting-input').val(),
        Intro: $('#home-intro-input').val(),
    };

    $.ajax({
        type: "POST",
        url: "/Home/UpdateHome",
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ homeContent: homeContentViewModel }),
        success: (data) => {
            if (data == "") {
                $('#signup-modal').modal('show');
            } else {
                var object = JSON.parse(data);
                if (object.result == "success") {
                    $('#home-greeting').text(object.greeting);
                    $('#home-intro').text(object.intro);
                    $('#home-editor').collapse('hide');
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

$('#home-editor').on('hidden.bs.collapse', function () {
    $('#home-edit').css('display', 'inline-block');
    $('.home-apply-changes').css('display', 'none');
    $('#home-greeting-input').val('');
    $('#home-intro-input').val('');
});

$('#home-editor').on('show.bs.collapse', function () {
    $('#home-greeting-input').val($('#home-greeting').text());
    $('#home-intro-input').val($('#home-intro').text());
});

$('#home-editor').on('shown.bs.collapse', function () {
    $('#home-edit').css('display', 'none');
    $('.home-apply-changes').css('display', 'inline-block');
});