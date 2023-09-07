function InitializeDatePicker() {
    // date picker
    $('.date-picker').datepicker({
        language:'en',
        autoClose: true,
        dateFormat: shortdatetimeformat,
        timepicker: false
    });   

    $("body").on("click", ".date-picker", function () {

        var val = $(this).val();

        var $datepicker = $(this).datepicker();        

        if (val !== null || val.trim() > 0) {

            $datepicker.val(val).show();
        }
        else
        {
            $datepicker.show();
        }        
    });
}