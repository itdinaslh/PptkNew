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
        lengthMenu: [5, 10, 20],
        ajax: {
            url: '/api/master/program/list',
            method: 'POST'
        },
        columns: [
            { data: 'programId', name: 'programId', searchable: false, orderable: false },
            { data: 'kodeProgram', name: 'kodeProgram' },
            { data: 'namaProgram', name: 'namaProgram' },
            {
                "render": function (data, type, row) {
                    return "<button class='btn btn-sm btn-outline-success mr-2 showMe' style='width:100%;' data-href='/auth/roles/edit/"
                        + row.id + "'><i class='fa fa-edit'></i> Edit</button>";
                }
            }
        ],
        order: [[0, "desc"]]
    });
}