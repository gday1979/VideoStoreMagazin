var dataTable;

$(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { data: "name", "width": "15%" },
            { data: "email", "width": "15%" },
            { data: "phoneNumber", "width": "15%" },
            { data: "company.name", "width": "15%" },
            { data: "role", "width": "15%" },
            {
                data: { id:'id',lockoutEnd:"lockoutEnd" },
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();
                    if (lockout > today) {
                        // user is currently locked
                        return `<div class="w-75 btn-group" role="group">
                              <a class="btn btn-danger mx-2" onclick=LockUnlock('${data.id}')><i class="bi bi-unlock"></i> Unlock</a>               
                              </div>`
                    }
                    else {
                        return `<div class="w-75 btn-group" role="group">
                              <a class="btn btn-success mx-2" onclick=LockUnlock('${data.id}')><i class="bi bi-lock"></i> Lock</a>               
                              </div>`
                    }
                    return `<div class="w-75 btn-group" role="group">
                              <a href="/admin/company/upsert?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
                              </div>`
                },
                "width": "25%"
            }
        ]   
    });
}
function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/admin/user/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
            else {
                toastr.error(data.message);
            }
        }
    })
}

