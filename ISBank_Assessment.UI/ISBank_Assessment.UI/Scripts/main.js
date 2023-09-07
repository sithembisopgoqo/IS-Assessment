// select jq
$(document).ready(function() {
    $('select').niceSelect();
});


// sidebar toggle button
$('#toggle-icon').on('click', function (e) {
    $('.sidebar-content').toggleClass("mini"); //you can list several class names
    e.preventDefault();
});

// checkout button, next btn --> submit btn
$('#nextsubmit').on('click', function () {
    $(this).closest(".nextsubmitbtn").remove();
    $(".checkout-submitnew-btn").addClass("show");
});




// table1

var table1 = $('#table1').DataTable({
    // lengthChange: false,
    "order": [[0, 'dsc']],
    "autoWidth": false,
    dom: 'rt',

});

var table4 = $('#table4').DataTable({
    // lengthChange: false,
    "order": [[0, 'dsc']],
    "autoWidth": false,
    dom: 'rt',

});

var table5 = $('#table5').DataTable({
    // lengthChange: false,
    "order": [[0, 'dsc']],
    "autoWidth": false,
    dom: 't',

});

var table6 = $('#table6').DataTable({
    // lengthChange: false,
    "order": [[0, 'dsc']],
    "autoWidth": false,
    dom: 'tp',

});


// Table 2
//     let tableSecond = $('#table2');
    var table = $('#table2').DataTable({
        // lengthChange: false,
        "order": [[0, 'dsc']],
        // "autoWidth": false,
        "pagingType": "full_numbers",
        dom: 'rtp',
    });

    $('#table2 tbody').on('click', 'td:first-child', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);
        // var rowHidden = row.closest('tr');
        // console.log(row);
        // console.log(rowHidden);
        if (row.child.isShown()) {
            // This row is already open - close it.
            row.child.hide();
            tr.removeClass('shown');
        } else {
            // Open row.
            row.child('<div class="table"><table id="table3"><thead><tr><th>asdad</th></tr></thead><tbody><tr><td colspan="11">11111</td><td>22222</td> </tr></tbody></table></div>').show();
            tr.addClass('shown');
        }
    });




// steps
$(document).ready(function () {
    $('.btnNext').click(function () {
        $('.nav-tabs .active').parent().next('li').find('a').trigger('click');
        $('.nav-tabs li:first-of-type a').addClass('active');
        $('.nav-tabs li a.active').parents().addClass('active');
    });

    $('.btnPrevious').click(function () {
        $('.nav-tabs .active').parent().prev('li').find('a').trigger('click');
        $('.nav-tabs li.active:last-of-type a.active').removeClass('active');
        $('.nav-tabs li.active:last-of-type').removeClass('active');
    });

    // toggle class
    $('.btnNext').on('click', function (e) {
        // $('.step-line1').toggleClass("active"); // nekoliko klasa moze da se izlista
        e.preventDefault();
    });

});


$("#table1_wrapper").append( $( ".table1-addtocartbuttons" ) );
$("#table4_wrapper").append( $( ".table4-addtocartbuttons" ) );


$(document).ready(function(){
    $('[data-toggle="tooltip"]').tooltip();

});


$(document).ready(function(){

    var current_fs, next_fs, previous_fs; //fieldsets
    var opacity;

    $(".next").click(function(){

        current_fs = $(this).parent();
        next_fs = $(this).parent().next();

//Add Class Active
        $("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");

//show the next fieldset
        next_fs.show();
//hide the current fieldset with style
        current_fs.animate({opacity: 0}, {
            step: function(now) {
// for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                next_fs.css({'opacity': opacity});
            },
            duration: 600
        });
    });

    $(".previous").click(function(){

        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();

//Remove class active
        $("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");

//show the previous fieldset
        previous_fs.show();

//hide the current fieldset with style
        current_fs.animate({opacity: 0}, {
            step: function(now) {
// for making fielset appear animation
                opacity = 1 - now;

                current_fs.css({
                    'display': 'none',
                    'position': 'relative'
                });
                previous_fs.css({'opacity': opacity});
            },
            duration: 600
        });
    });

    $('.radio-group .radio').click(function(){
        $(this).parent().find('.radio').removeClass('selected');
        $(this).addClass('selected');
    });

    $(".submit").click(function(){
        return false;
    })

});



// table with child

$(document).ready(function() {
    var table = $('#childTable').DataTable( {

        ajax: function (data, callback, settings) {
            $.ajax({
                url: "assets/ajax/objects.txt",
            }).then ( function(json) {
                var data = JSON.parse(json);
                callback(data);

            });
        },
        pageLength: 5,
        columns: [
            {
                "className":     'details-control',
                "orderable":      false,
                "data":           null,
                "defaultContent": ''
            },
            { "data": "name" },
            { "data": "description" },
            { "data": "min" },
            { "data": "max" },
            { "data": "default" },
            { "data": "status" },
            { "data": "occurrence" },
            { "data": "charge period" },
            { "data": "currency" },
            { "data": "cost price" },
            { "data": "action" }
        ],
        "columnDefs":
            [{
                "targets": 0,
                "data": null,
                "render": function (data, type, row, meta) {
                    return '<img src="assets/images/icons/childtable-arrowDown.png'  + '"height="6" width="10"/>';
                }

            },
                {
                    "targets": 11,
                    "data": null,
                    "render": function (data, type, row, meta) {
                        return '<img src="assets/images/icons/icon-tableChild-edit.png'  + '"height="20" width="17"/>';
                    }
                },
                {
                    "targets": 6,
                    "className":      'statusGreenText',
                }
            ],
        order: [[1, 'asc']],
        "scrollY":        "300px",
        "scrollCollapse": true,
        initComplete: function () {
            init = false;
        },
        createdRow: function ( row, data, index ) {
            if (data.extn === '') {
                var td = $(row).find("td:first");
                td.removeClass( 'details-control' );
            }
        },
        rowCallback: function ( row, data, index ) {
            //console.log('rowCallback');
        }
    }
    );

    // Add event listener for opening and closing first level childdetails
    $('#childTable tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row( tr );
        var rowData = row.data();

        //get index to use for child table ID
        var index = row.index();
        console.log(index);

        if ( row.child.isShown() ) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            // Open this row
            row.child(
                '<table class="child_table" id = "child_details' + index + '" cellpadding="5" cellspacing="0" border="0">'+
                '<thead><tr><th></th><th>Selling Price</th><th>Expiry date</th></tr></thead><tbody>' +
                '</tbody></table>').show();

            var childTable = $('#child_details' + index).DataTable({
                ajax: function (data, callback, settings) {
                    $.ajax({
                        url: "assets/ajax/child.txt",
                    }).then ( function(json) {
                        var data = JSON.parse(json);
                        data = data.data;

                        var display = [];
                        for (d = 0; d < data.length; d++) {
                            if (data[d].position == rowData.position) {
                                display.push(data[d]);
                            }
                        }
                        callback({data: display});

                    });
                },
                columns: [
                    {
                        "className":      'd-none',
                        "orderable":      false,
                        "data":           null,
                        "defaultContent": ''
                    },
                    { "data": "selling price" },
                    { "data": "expiry date" }
                ],
                destroy: true,
            });
            tr.addClass('shown');
        }



    } ),
    table.columns().iterator( 'column', function (ctx, idx) {
        $( table.column(idx).header() ).append('<span class="sort-icon"/>');
    } );
} );