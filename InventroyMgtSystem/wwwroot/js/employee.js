var dataTable;

$(function () {
    handleDataTable()
}
)
function handleDataTable() {
    dataTable = $("#dataLoad").DataTable({
        "ajax": {
            url: "/employee/GetAll",
            type: "Get",
            dataType: "json"
        },
        "columns": [
            { data: "fullName", width: "25%" },
            { data: "email", width: "25%" },
            { data: "phoneNumber", width: "25%" },
            {
                data: { id: "id", lockEnd: "lockEnd" },
                render: function (data) {
                    var lockDate = new Date(data.lockoutEnd).getTime();
                    var todayDate = new Date().getTime();
                    if (lockDate > todayDate) {
                        return `
                        <div class="text-center">
                                <a onclick=LockUnLock("/employee/lockUnlock/${data.id}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                <i class="fas fa-lock-open"></i> Unlock
                                </a>
                         </div>
                      `
                    }
                    else {
                        return `
                        <div class="text-center">
                                
                                <a onclick=LockUnLock("/employee/lockUnlock/${data.id}") class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                <i class="fas fa-lock"></i> Lock
                                </a>
                         </div>
                      `
                    }
                },
                width: "25%"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        }
    })
};


function LockUnLock(url) {
    $.ajax({
        url: url,
        type: "POST",
        success: function (data) {
            if (data.status) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
            else {
                toastr.error(data.message);
            }
        }
    });

}