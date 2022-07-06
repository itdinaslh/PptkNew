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
            url: '/api/master/jenis-pengadaan/list',
            method: 'POST'
        },
        columns: [
            { data: 'jenisPengadaanId', name: 'jenisPengadaanId', searchable: false, orderable: false },
            { data: 'namaJenis', name: 'namaJenis' },            
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/master/jenis-pengadaan/edit/?id="
                        + row.jenisPengadaanId + "'><i class='fa fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}