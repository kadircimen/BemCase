$(document).ready(function () {
    //LIST
    GetList(0);
    //POST
    $('#healthCheckForm').submit(function (e) {
        e.preventDefault();

        var app = {
            AppName: $('#appName').val(),
            Url: $('#url').val(),
            Unit: $('#unitVal').val(),
            Frequency: $('#frequency').val()
        };
        ajaxServices.post('/HealthCheck/CreateHealthCheckUrl', app, function (response) {
            alertMessages.success('URL Saved' + response.AppName);
        }, function (error) {
            alertMessages.error(error.responseJSON.Detail);
        });
    });
    function GetList(pageNo) {
        var queryParams = {
            PageSize: 2,
            Page: pageNo
        };
        ajaxServices.get('/HealthCheck/GetHealthCheckUrlList', queryParams, function (response) {
            var pageItems = '';
            for (var i = 1; i <= response.Pages; i++) {

                pageItems += `<li class="page-item"><a href="#" data-key='no' data-go="${i - 1}" class="page-link ${i == (response.Index + 1) ? 'active' : ''}" data-page="${i}" ${i == (response.Index + 1) ? 'aria-current="page"' : ''}>${i}</a></li>`;
            }
            var pagination =
                `<li id="pagePrev" class="page-item ${response.HasPrevious ? '' : 'disabled'}">
                    <a class="page-link"  href="#" tabindex="-1" aria-disabled="${response.HasPrevious}" data-key='prev' data-has="${response.HasPrevious}" data-go="${(response.Index-1)}">Previous</a>
                </li>
                ${pageItems}
                <li class="page-item ${response.HasNext ? '' : 'disabled'}">
                    <a class="page-link" type="button" data-key='next' data-has="${response.HasNext}" data-go="${(response.Index + 1)}">Next</a>
                </li>`;

            $('#pagination').html(pagination);

            console.log(response);
        }, function (error) {
            console.log(error);
        });
    }

    $('#pagination').on('click', '.page-item a', function () {

        var pageNo = $(this).data('page');
        var key = $(this).data('key');
        var has = $(this).data('has');
        var go = $(this).data('go');
        GetList(parseInt(go));
        //GetList(pageNo - 1); // Sayfa numarasını index olarak gönder
    });
});