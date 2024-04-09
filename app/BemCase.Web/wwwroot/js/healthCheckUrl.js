$(document).ready(function () {
    const Frequencies = {
        Minute: 1,
        Hour: 2,
        Day: 3
    }
    const FrequencyText = {
        [Frequencies.Minute]: 'Minute(s)',
        [Frequencies.Hour]: 'Hour(s)',
        [Frequencies.Day]: 'Day(s)'
    }
    function getFreqText(no) {
        return FrequencyText[no] || 'Unknown';
    }
    function GetList(pageNo) {
        var queryParams = {
            PageSize: 5,
            Page: pageNo
        };
        ajaxServices.get('/HealthCheck/GetHealthCheckUrlList', queryParams, function (response) {
            var pageItems = '';
            for (var i = 1; i <= response.Pages; i++) {
                if (i === (response.Index + 1)) {
                    pageItems += `<li class="page-item active" aria-current="page"><span class="page-link">${i}</span></li>`;
                } else {
                    pageItems += `<li class="page-item"><a href="#" data-go="${i - 1}" class="page-link" data-page="${i}">${i}</a></li>`;
                }
            }
            var pagination =
                `<li id="pagePrev" class="page-item ${response.HasPrevious ? '' : 'disabled'}">
                    <a class="page-link"  href="#" tabindex="-1" aria-disabled="${response.HasPrevious}" data-go="${(response.Index - 1)}">Previous</a>
                </li>
                ${pageItems}
                <li class="page-item ${response.HasNext ? '' : 'disabled'}">
                    <a class="page-link" type="button" data-go="${(response.Index + 1)}">Next</a>
                </li>`;

            $('#pagination').html(pagination);
            var tableData = '';
            response.Items.forEach(function (x, i) {
                tableData += `<tr>
                <td>${x.AppName}</td>
                <td>${x.Url}</td>
                <td>Every ${x.Unit} ${getFreqText(x.Frequency)}</td>
                <td style="width:150px;">
                    <button type="button" class="btn btn-outline-info btn-edit" data-id="${x.Id}">
                        <i class="bi bi-pencil"></i>
                    </button>
                    <button type="button" class="btn btn-outline-danger btn-delete" data-id="${x.Id}">
                        <i class="bi bi-trash"></i>
                    </button>
                </td>
            </tr>`;
            });
            $('#tableData').html('');
            $('#tableData').html(tableData);
        }, function (error) {
            alertMessages.error(error.responseJSON.Detail);
        });
    }
    GetList(0);

    $('#healthCheckForm').submit(function (e) {
        e.preventDefault();
        var app = {
            Id: $('#idVal').val(),
            AppName: $('#appName').val(),
            Url: $('#url').val(),
            Unit: $('#unitVal').val(),
            Frequency: $('#frequency').val()
        };
        if ($('#idVal').val()) {
            ajaxServices.post('/HealthCheck/UpdateHealthCheckUrl', app, function (response) {
                alertMessages.success('URL Saved - ' + JSON.parse(response).AppName);
                GetList(0);
            }, function (error) {
                alertMessages.error(error.responseJSON.Detail);
            });
        }
        else {
            ajaxServices.post('/HealthCheck/CreateHealthCheckUrl', app, function (response) {
                alertMessages.success('URL Saved - ' + JSON.parse(response).AppName);
                GetList(0);
            }, function (error) {
                alertMessages.error(error.responseJSON.Detail);
            });
            $('#healthCheckForm')[0].reset();
        }
    });



    $('#pagination').on('click', '.page-item a', function () {
        var go = $(this).data('go');
        GetList(parseInt(go));
    });
    $('#tableData').on('click', '.btn-edit', function () {
        $('#idVal').val($(this).data('id'));
        var queryParams = {
            Id: $('#idVal').val()
        }
        ajaxServices.get('/HealthCheck/GetHealthCheckUrlById', queryParams, function (response) {
            $('#appName').val(response.AppName);
            $('#url').val(response.Url);
            $('#unitVal').val(response.Unit);
            $('#frequency').val(response.Frequency);
            $('#resetformBtn').show();
        });
    });

    $('#tableData').on('click', '.btn-delete', function () {
        var queryParams = {
            Id: $(this).data('id')
        }
        ajaxServices.post('/HealthCheck/DeleteHealthCheckUrl', queryParams, function (response) {
            alertMessages.success('URL Deleted - ' + JSON.parse(response).AppName);
            GetList(0);
        }, function (error) {
            alertMessages.error(error.responseJSON.Detail);
        });
    });
    $('#resetformBtn').click(function () {
        $(this).hide();
    });
});