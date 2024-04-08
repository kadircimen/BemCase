var ajaxServices = (function () {
    function get(url, queryData, successCallback, errorCallback) {
        console.log(JSON.stringify(queryData))
        $.ajax({
            url: url,
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            data: queryData,
            dataType: "json",
            success: successCallback,
            error: errorCallback
        });
    }

    function post(url, data, successCallback, errorCallback) {
        $.ajax({
            url: url,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: successCallback,
            error: errorCallback
        });
    }

    return {
        get: get,
        post: post
    };
})();
