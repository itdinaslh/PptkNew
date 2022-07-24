$(document).ready(function () {
    loadTable();
});

function loadContent() {
    loadTable();
}

function loadTable() {
    $('#tblData').DataTable().destroy();
    $('#tblData').DataTable({
        serverSide: true,
        processing: true,
        responsive: true,
        stateSave: true,
        lengthMenu: [5, 10, 20],
        ajax: {
            url: '/api/administrator/user-skpd/list',
            method: 'POST'
        },
        columns: [
            { data: 'userSkpdId', name: 'userSkpdId', searchable: false, orderable: false },
            { data: 'userName', name: 'userName' },
            { data: 'skpdName', name: 'skpdName' },
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/administrator/user-skpd/edit/?id="
                        + row.userSkpdId + "'><i class='fa fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

$(document).on('shown.bs.modal', function () {
    $('#cbSkpd').select2({
        placeholder: 'Pilih SKPD...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/administrator/skpd/search",
            contentType: "application/json; charset=utf-8",
            data: function (params) {
                var query = {
                    term: params.term,
                };
                return query;
            },
            processResults: function (result) {
                return {
                    results: $.map(result, function (item) {
                        return {
                            text: item.skpdName,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
});