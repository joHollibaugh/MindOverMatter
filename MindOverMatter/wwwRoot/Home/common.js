function JSONPost(url, parameters, successCallback) {

    $.ajax({
        type: 'POST',
        url: url,
        data: parameters,
        //contentType: 'application/json;',
        dataType: 'json',
        success: successCallback,
        error: function (xhr, textStatus, errorThrown) {
            console.log('error');
        }
    });
};

function JSONModalPost(url, parameters, successCallback) {

    $.ajax({
        type: 'POST',
        url: url,
        data: parameters,
        //contentType: 'application/json;',
        dataType: 'html',
        success: successCallback,
        error: function (xhr, textStatus, errorThrown) {
            console.log('error');
        }
    });
};
