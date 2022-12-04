const SaveApiUrl = 'api/v1/saveurl';

function createAliase() {
    let fullUrl = $('#link-inp').val();
    let request = { 'OriginalUrl': fullUrl };
    $.ajax({
        url: SaveApiUrl,
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        data: JSON.stringify(request),
        success: (resp) => {
            console.log(resp);
            $('#code-contaider-img').attr('src', resp.bitmapCodeAddress);
            $('#link-inp').val(resp.shortLink);
        }
    });
}