$('#home-edit').on('click', () => {
    $('#home-edit').css('display', 'none');
    $('.home-apply-changes').css('display', 'inline-block');

    $('#home-greeting-input').val($('#home-greeting').text());
    $('#home-intro-input').val($('#home-intro').text());
});

$('#home-edit-save').on('click', () => {
    $('#home-edit').css('display', 'inline-block');
    $('.home-apply-changes').css('display', 'none');

    $('#home-greeting').text($('#home-greeting-input').val());
    $('#home-intro').text($('#home-intro-input').val());
    $('#home-greeting-input').val('');
    $('#home-intro-input').val('');
});

$('#home-edit-cancel').on('click', () => {
    $('#home-edit').css('display', 'inline-block');
    $('.home-apply-changes').css('display', 'none');

    $('#home-greeting-input').val('');
    $('#home-intro-input').val('');
});