// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var toggler = document.getElementsByClassName("caret");
    var i;

    for (i = 0; i < toggler.length; i++) {
        toggler[i].addEventListener("click", function () {
            this.parentElement.querySelector(".nested").classList.toggle("active");
            this.classList.toggle("caret-down");
        });
    }

    $('#qr').click(function (e) {
        e.preventDefault();
    });


    $('.table-data').DataTable().destroy();
    var t =  $('.table-data').DataTable({   
        "columnDefs": [{
            "searchable": false,
            "orderable": false,
            "targets": 0
        }],
        "order": [[1, 'asc']],
        "language": {
            "lengthMenu": "Hiển thị số dòng trên một trang _MENU_",
            "zeroRecords": "Không có bản ghi nào",
            "info": "Trang _PAGE_ / _PAGES_ tổng số _TOTAL_ tài sản",
            "infoEmpty": "Không có bản ghi nào",
            "infoFiltered": "(Kết quả trả về được duyệt trên tổng _MAX_ bản ghi)",
            "search": "Tìm kiếm:",
            "paginate": {
                "first": "Về đầu",
                "last": "Đến cuối",
                "next": "Tiếp",
                "previous": "Trước"
            },
        },
        select: {
            style: 'multi'
        },
        "pageLength": 15,
        "bLengthChange": true,
        buttons: ['pdf', 'colvis']
    });
    t.on('order.dt search.dt', function () {
        t.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
    $(".dataTables_filter input").unbind();
    $(".dataTables_filter input").bind('keyup', function (e) {
        if (e.keyCode == 13) {
            $('.table-data').DataTable().search(this.value).draw();
        }
    });
});

//$(document).ready(function () {
//    $('#BudgetSource').on('keyup', function () { SumPrice(); });
//    $('#CareerSource').on('keyup', function () { SumPrice(); });
//    $('#AidSource').on('keyup', function () { SumPrice(); });
//    $('#AnotherSource').on('keyup', function () { SumPrice(); });
//    function SumPrice() {
//        var value1 = parseFloat($('#BudgetSource').val());
//        var value2 = parseFloat($('#CareerSource').val());
//        var value3 = parseFloat($('#AidSource').val());
//        var value4 = parseFloat($('#AnotherSource').val());
//        $('#Price').val((value1 + value2 + value3 + value4));
//    }
//    $('#wareHouseID').val($('#wareHouse').val());
//    $('#wareHouseName').text($('#wareHouse option:selected').text());
//    if ($('#checkGroup').val() == null || $('#checkGroup').val() == "") {

//    }
//    else {
//        GetGroups($('#assetType').val());
//    }
//});
//$('#assetType').on('change', function () {
//    GetGroups(this.value);
//});
//var idToSend;
//function GetGroups(idToSend) {
//    var target = document.getElementById("assetGroup");
//    $.ajax({
//        url: "GetAssetGroup",
//        type: 'POST',
//        data: {
//            IdToSearch: idToSend
//        },
//        dataType: 'json',
//        success: function (data1) {
//            var count;
//            removeOptions(document.getElementById("assetGroup"));
//            for (count = 0; count < data1.length; count++) {
//                var option = document.createElement("option");
//                option.text = data1[count].name;
//                option.value = data1[count].id;
//                if ($('#checkGroup').val()) {
//                    if ($('#checkGroup').val() == data1[count].assetType.id)
//                        option.selected = true;
//                }
//                target.add(option);
//            }
//        }
//    });
//}
//function removeOptions(selectElement) {
//    var i, L = selectElement.options.length - 1;
//    for (i = L; i >= 0; i--) {
//        selectElement.remove(i);
//    }
//}
$('#checkall').on('change', function () {
    if ($(this).is(":checked")) {
        $('.checkitem').each(function () {
            var text = $('#valueToChange').text();
            $('#valueToChange').text(text + $(this).attr("id") + "**");
            $(this)[0].checked = true;
        });
    }
    else {
        $('.checkitem').each(function () {
            $('#valueToChange').text("");
            $(this)[0].checked = false;
        });
    }
});
$('.checkitem').on('change', function () {
    var text = $('#valueToChange').text();
    if ($(this).is(":checked")) {
        $('#valueToChange').text(text + $(this).attr("id")+"**");
    }
    else {
       
        $('#valueToChange').text(text.replace($(this).attr("id") + "**",""));
    }
});
