var dataTable;

$(function () {
    handleDataTable()
}
)
function handleDataTable() {
    dataTable = $("#dataLoad").DataTable({
        "ajax": {
            url: "/InventoryItems/GetAll",
            type: "Get",
            dataType: "json"
        },
        "columns": [
            { data: "name", width: "20%" },
            { data: "category.name", width: "25%" },
            { data: "price", width: "20%" },
            {
                data: "id",
                render: function (data) {
                    return `
                        <div>
                              <a href="/InventoryItems/upset?id=${data}" class="btn btn-success text-white" style="cursor:pointer;">
                                <i class="fas fa-edit"></i> Edit
                                </a>
                                <a onclick=Delete("/InventoryItems/delete/${data}") class="btn btn-danger text-white" style="cursor:pointer;">
                                <i class="fas fa-trash-alt"></i> Delete
                                </a>
                         </div>
`
                },
                width: "35%"
            }
        ],
        "language": {
            "emptyTable": "No data found"
        }
    })
};

function Delete(url) {
    swal({
        title: "You are sure you want to delete",
        text: "You won't be able to restore the data",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then(response => {
        if (response) {
            $.ajax({
                url: url,
                type: "DELETE",
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
    })
}