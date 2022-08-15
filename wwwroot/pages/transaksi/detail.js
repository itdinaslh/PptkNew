$(document).ready(function () {
    loadTable();
    ComputeTotal();

    $('.autonumber').autoNumeric('init', { currencySymbol: 'Rp. ', allowDecimalPadding: false, digitGroupSeparator: '.', decimalCharacter: ',' });

    LoadNoRekening();
    LoadPenyedia();
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
        ajax: {
            url: '/api/transaksi/detail/list?trans=' + trans,
            method: 'POST'
        },
        columns: [            
            { data: 'kodeRekening', name: 'kodeRekening', orderable: false },
            { data: 'namaRekening', name: 'namaRekening' },
            { data: 'anggaran', name: 'anggaran' },
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-success showMe' style='margin-right:5px;' data-href='/transaksi/detail/edit/?id="
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
    LoadModalRekening();

    var anggaran = $('#rModalAnggaran').val();
    $('#txtModalAnggaran').val(anggaran);
    $('#txtModalAnggaran').autoNumeric('init', { currencySymbol: 'Rp. ', allowDecimalPadding: false, digitGroupSeparator: '.', decimalCharacter: ',' });
});

$(document).on('keyup', '#txtAnggaran', function () {
    var jumlah = $(this).autoNumeric('get');
    $('#rAnggaran').val(jumlah);
});

$(document).on('keyup', '#txtModalAnggaran', function () {
    var jumlah = $(this).autoNumeric('get');
    $('#rModalAnggaran').val(jumlah);
});

$(document).on('click', '#btnTambah', function () {
    ShowFrmTambah();
});

$(document).on('click', '#btnCancel', function () {
    HideFrmTambah();
});

$(document).on('click', '#btnAddKontrak', function () {
    ShowFrmKontrak();
});

$(document).on('click', '#btnCancelKontrak', function () {
    HideFrmKontrak();
});

function ShowFrmTambah() {
    $('#frmTambah').show();
    $('#tblTrans').hide();
    $('#sRekening').val("").trigger('change');
    $('#txtAnggaran').val("");
}

function HideFrmTambah() {
    $('#frmTambah').hide();
    $('#tblTrans').show();
    $('#sRekening').val("").trigger('change');
    $('#txtAnggaran').val("");
}

function ShowFrmKontrak() {
    $('#frmAddKontrak').show();
    $('#cardKontrak').hide();
    $('#sPenyedia').val("").trigger('change');    
}

function HideFrmKontrak() {
    $('#frmAddKontrak').hide();
    $('#cardKontrak').show();
    $('#sPenyedia').val("").trigger('change');
}

$('#frmRekening').submit(function (e) {
    e.preventDefault();

    $.ajax({
        url: this.action,
        type: this.method,
        data: $(this).serialize(),
        success: function (result) {
            if (result.success) {
                RekSuccessAdded();
                HideFrmTambah();
            } else {
                showInvalidMessage();
            }
        }
    });
});

function LoadNoRekening() {
    $('#sRekening').select2({
        placeholder: 'Pilih Rekening...',        
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
    }).on('select2:open', () => {
        $(".select2-results:not(:has(a))").append('<a href="javascript:void(0)" id="addRekening" class="showMe closeDown" data-href="/master/rekening/create" style="padding: 6px;height: 20px;display: inline-table;">Tambah baru</a>');
    });
}

$(document).on('click', '.closeDown', function() {
    $(document.body).trigger('mousedown');
});

function LoadModalRekening() {
    $('#sModalRekening').select2({
        placeholder: 'Pilih Rekening...',
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
}

function LoadPenyedia() {
    $('#sPenyedia').select2({
        placeholder: 'Pilih Penyedia...',
        allowClear: true,
        ajax: {
            url: "/api/master/penyedia/search",
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
                            text: item.namaPenyedia,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}

function RekSuccessAdded() {
    Swal.fire({
        position: 'top-end',
        type: 'success',
        title: 'Data berhasil disimpan!',
        showConfirmButton: false,
        timer: 1000
    }).then(function () {
        loadTable();
        ComputeTotal();
    });
}