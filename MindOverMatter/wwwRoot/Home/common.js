

function JSONPost(url, parameters, successCallback) {

    $.ajax({
        type: 'POST',
        url: url,
        data: JSON.stringify(parameters),
        contentType: 'application/json;',
        dataType: 'json',
        success: successCallback,
        error: function (xhr, textStatus, errorThrown) {
            console.log('error');
        }
    });
}

