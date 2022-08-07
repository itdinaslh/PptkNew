$(document).on('shown.bs.modal', function () {
    PopulateProgram();
    PopulateKegiatan();
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