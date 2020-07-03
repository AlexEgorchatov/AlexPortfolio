//$(() => {
//    $('#work-carousel').carousel();
//});

$('#work-job-details').on('shown.bs.modal', () => {
    $('#work-carousel').carousel();
});