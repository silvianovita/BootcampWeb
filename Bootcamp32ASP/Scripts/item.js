//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
    $('#products').DataTable({
        "order": [[1, "desc"]]
    });
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Items/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            const obj = JSON.parse(result);
            $.each(obj, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Stock + '</td>';
                html += '<td>' + item.Price + '</td>';
                html += '<td>' + item.tb_m_supplier.Name+ '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.ID + ')">Edit</a> | <a href="#" onclick="Delete(' + item.ID + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
            table.rows({ order: 'applied' }).data()
           
        },
        error: function (errormessage) {
            console.log(errormessage.responseText);
        }
    });
    $('#products').DataTable({
        "order": [[1, "desc"]]
    });
    var table = $('#products').DataTable();

    // Sort by column 1 and then re-draw
    table
        .order([1, 'asc'])
        .draw();
}  

function Add() {

}

function getbyId(id) {

}

function Delete(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            Swal.fire(
                'Deleted!',
                'Your file has been deleted.',
                'success'
            )
        }
    })
}