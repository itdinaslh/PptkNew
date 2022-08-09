var selectedKegiatan = "";

function loadContent() {
    $('#transTable').load(' #transTable');
}

$(document).on('shown.bs.modal', function () {
    PopulateProgram();
    PopulateKegiatan();
    $('#sSubKegiatan').select2();
});

$(document).on('change', '#sKegiatan', function () {
    var kegiatan = $(this).val();
    if (kegiatan != '' || kegiatan != null) {
        $('#sSubKegiatan').prop('disabled', false);
        PopulateSubKegiatan(kegiatan);
    }
});

$('#sKegiatan').on('select2:clear', function () {
    $('#sSubKegiatan').val('');
    $('#sSubKegiatan').prop('disabled', true);
});

function PopulateProgram() {
    $('#sProgram').select2({
        placeholder: 'Pilih Program...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/program/search",
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
                            text: item.namaProgram,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}

function PopulateKegiatan() {
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
}

function PopulateSubKegiatan(kegiatanId) {
    $('#sSubKegiatan').select2('destroy');
    $('#sSubKegiatan').select2({
        placeholder: 'Pilih Sub Kegiatan...',
        dropdownParent: $('#myModal'),
        allowClear: true,
        ajax: {
            url: "/api/master/subkegiatan/search/?kegiatanId=" + kegiatanId,
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
                            text: item.namaSubKegiatan,
                            id: item.id
                        }
                    })
                }
            },
            cache: true
        }
    });
}