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
            url: '/api/master/penyedia/list',
            method: 'POST'
        },
        columns: [
            { data: 'penyediaId', name: 'penyediaId', searchable: false, orderable: false },
            { data: 'namaPenyedia', name: 'namaPenyedia' },
            { data: 'alamat', name: 'alamat' },
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-success mr-2 showMe' style='width:100%;' data-href='/master/penyedia/edit/?id="
                        + row.penyediaId + "'><i class='fa fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}