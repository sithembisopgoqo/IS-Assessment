function ErrorHandler(responseText, textStatus, XMLHttpRequest) {
    if (textStatus == "error") {
        //alert(responseText);
        //$("#dialog").html(responseText);
        //$('#myerrormodal').modal('show');
        //urlbinder();
    }
    else {
        urlbinder();
    }


}


$(document).ajaxError(function (event, jqxhr, settings, exception) {

    var error = $.parseJSON(jqxhr.responseText);
    $("#dialog").html(error.Message);
    //$("#dialog").append(error.StackTrace);
    $('#myerrormodal').modal('show');

    //if(x.status==0){
    //        alert('You are offline!!\n Please Check Your Network.');
    //    }else if(x.status==404){
    //        alert('Requested URL not found.');
    //    }else if(x.status==550){ // <----- THIS IS MY CUSTOM ERROR CODE --------
    //        alert(x.responseText);
    //    }else if(x.status==500){
    //        alert('Internel Server Error.');
    //    }else if(e=='parsererror'){
    //        alert('Error.\nParsing JSON Request failed.');
    //    }else if(e=='timeout'){
    //        alert('Request Time out.');
    //    }else {
    //        alert('Unknow Error.\n'+x.responseText);
    //    }
});

function urlbinder() {
    $('.chosen-select').chosen({ search_contains: "true", width:'100%', placeholder_text_single: "Select an option..." }); // MAXINE: removed Width:"100%"


    $('.loadstate').on('click', function (item) {
        $('.loadstate').attr('data-loading-text', 'Loading...');
        $('.loadstate').button('reset');
        $(this).button('loading');
    });

    $("[data-url]").each(function (index, item) {

        $(item).off('click');
        $(item).on('click', function (e) {

            var url = $(item).data("url");
            var target = $(item).data("urltargetid");
            var loader = $(item).data("urlnoloader");

            if (!loader) {
                var urlPath = getHome() + "/images/ajax-loader.gif";
                $('#' + target).html('<img id="loading" src="' + urlPath + '" />');
            }

            if ($('#' + target).length) {
                $('#' + target).load(url, ErrorHandler);
            }
            else {
                alert('Div does not exist, therefore no data can be loaded into it: ' + target);
            }

        });
    });
 
}

function Loader(div) {
    var urlPath = getHome() + "/images/ajax-loader.gif";

    $(div).html('<img id="loading" src="' + urlPath + '" />');
}

