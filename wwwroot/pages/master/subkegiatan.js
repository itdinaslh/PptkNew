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
            url: '/api/master/subkegiatan/list',
            method: 'POST'
        },
        columns: [
            { data: 'subKegiatanId', name: 'subKegiatanId', searchable: false, orderable: false },
            { data: 'kodeSubKegiatan', name: 'kodeSubKegiatan' },
            { data: 'namaSubKegiatan', name: 'namaSubKegiatan' },
            { data: 'namaKegiatan', name: 'namaKegiatan'},
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/master/subkegiatan/edit/?id="
                        + row.subKegiatanId + "'><i class='fa fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}

$(document).on('shown.bs.modal', function () {
    $('#sKegiatan').select2({
        placeholder: 'Pilih Kegiatan...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/kegiatan/search",
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
                            text: item.namaKegiatan,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
});