$(document).ready(function () {
    loadTable();
    ComputeTotal();
});

function loadContent() {
    loadTable();
    ComputeTotal();
}

function loadTable() {
    var trans = $("#TransID").val();

    $('#tblData').DataTable().destroy();
    $('#tblData').DataTable({
        serverSide: true,
        processing: true,
        paging: false,
        ordering: false,
        searching: false,
        info: false,
        responsive: true,
        stateSave: true,
        lengthMenu: [5, 10, 20],
        ajax: {
            url: '/api/transaksi/detail/list?trans=' + trans,
            method: 'POST'
        },
        columns: [            
            { data: 'kodeRekening', name: 'kodeRekening' },
            { data: 'namaRekening', name: 'namaRekening' },
            { data: 'anggaran', name: 'anggaran' },
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-success showMe' style='margin-right:5px;' data-href='/master/transaksi/edit/?id="
                        + row.transDetailId + "'><i class='fa fa-edit'></i></button><button class='btn btn-sm btn-danger delBtn' data-id='"
                        + row.transDetailId + "'><i class='fa fa-trash'></i></button > ";
                }
            }
        ],
        columnDefs: [
            { className: 'align-middle', targets: [0,1]},
            { className: 'text-end align-middle', targets: [2] },
            { className: 'text-center', targets: [3] }
        ]
    });
}

function ComputeTotal() {
    var trans = $("#TransID").val();

    $.ajax({
        url: '/api/transaksi/detail/sum/?id=' + trans,
        dataType: 'json',
        method: 'GET',
        success: function (response) {
            $('#TotalTrans').html(response.total);
        }
    });
}

function DeleteDetail(id) {
    $.ajax({
        url: '/transaksi/detail/delete/?id=' + id,
        dataType: 'json',
        method: 'POST',
        success: function (response) {
            if (response.success) {
                loadTable();
                ComputeTotal();
            }
        }
    });
}

$(document).on('click', '.delBtn', function () {
    var id = $(this).attr('data-id');

    DeleteDetail(id);
});

$(document).on('shown.bs.modal', function () {
    $('#sRekening').select2({
        placeholder: 'Pilih Rekening...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/rekening/search",
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
                            text: item.namaRekening,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
});