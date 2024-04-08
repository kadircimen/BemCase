var alertMessages = (function () {
    function error(message) {
        $('#alertPlaceholder').html('');
        $('#alertPlaceholder').append(
            `<div class="alert alert-danger alert-dismissible fade show" role="alert">
                ${message}
                <button type="button" class="close position-absolute" style="right: 0; top: 0; z-index:9999; background: none; border: none; shadow: none;" data-bs-dismiss="alert" aria-label="Close">
                <span aria-hidden="true" style="font-size: 20px;">&times;</span>
                </button>
                </div>`
        );
    }
    function success(message) {
        $('#alertPlaceholder').html('');
        $('#alertPlaceholder').append(
            `<div class="alert alert-success alert-dismissible fade show" role="alert">${message}</div>
            <button type="button" class="close position-absolute" style="right: 0; top: 0; z-index:9999; background: none; border: none; shadow: none;" data-bs-dismiss="alert" aria-label="Close">
            <span aria-hidden="true" style="font-size: 20px;">&times;</span>
            </button>`
        );
    }
    return {
        error: error,
        success: success
    };
})();
