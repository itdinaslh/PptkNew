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