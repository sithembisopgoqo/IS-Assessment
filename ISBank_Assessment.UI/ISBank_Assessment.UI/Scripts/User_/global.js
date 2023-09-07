$.validator.setDefaults({
    ignore: ".ignore,[data-val-ignore=ignore],:hidden",

    highlight: function (element) {
        var elem = $(element);

        if (elem.hasClass("select2-hidden-accessible")) {
            $("#select2-" + elem.attr("id") + "-container").parent().addClass('has-error');
            $(element).closest('.form-group').addClass('has-error');
        }
        else {
            $(element).closest('.form-group').addClass('has-error');
        }
        
        /*$(element).addClass('form-control-danger');*/
    },
    unhighlight: function (element) {
        var elem = $(element);
        if ($(element).hasClass("select2-hidden-accessible") || $(element).hasClass("is-valid-class")) {
            $("#select2-" + elem.attr("id") + "-container").parent().removeClass('has-error');
            $(element).closest('.form-group').removeClass('has-error');
            $(element).closest('.form-group').find('span.help-block').remove();
        }
        else {
            $(element).closest('.form-group').removeClass('has-error');
            $(element).closest('.form-group').find('span.help-block').remove();
        }
        /*$(element).removeClass('form-control-danger');*/
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if ($(element).closest('.form-group').length) {

            error.insertAfter(element.parent());
        } else {

            error.insertAfter(element);
        }
    }
    ,
    showErrors: function (errorMap, errorList) {
        //alert(errorList.length);
        

        this.defaultShowErrors();

        for (var i = 0; i < errorList.length; i++) {
            var error = errorList[i];
            if ($(error.element).closest('.form-group').find('span.help-block').length === 0) {
                $(error.element).closest('.form-group').append("<span class = 'help-block'>" + error.message + "</span>");

            }
            else if ($(error.element).closest('.form-group').find('span.help-block').length !== 0 && $(error.element).closest('.form-group').find('span.help-block').html() !== error.message) {
                $(error.element).closest('.form-group').find('span.help-block').remove();
                $(error.element).closest('.form-group').append("<span class = 'help-block'>" + error.message + "</span>");
            }
            
        }

    }
});



function ClearErrors(element) {
    // get the form inside we are working - change selector to your form as needed
    var $form = $('#' + element);

    // get validator object
    var $validator = $form.validate();

    $('#' + element + ' .has-error')
        .removeClass('has-error');

    $validator.resetForm();
}

function getHome() {
    return document.getElementById("ApplicationRoot").href;
}

function convertDateddMMyyyy(inputFormat) {
    function pad(s) { return (s < 10) ? '0' + s : s; }
    var d = new Date(inputFormat);
    return [pad(d.getDate()), pad(d.getMonth() + 1), d.getFullYear()].join('/');
}

function convertDateyyyyMMdd(inputFormat) {
    function pad(s) { return (s < 10) ? '0' + s : s; }
    var d = new Date(inputFormat);
    return [d.getFullYear(), pad(d.getMonth() + 1), pad(d.getDate())].join('/');
}

function GetDateddMMyyyy() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd;
    }
    if (mm < 10) {
        mm = '0' + mm;
    }
    var date = dd + '/' + mm + '/' + yyyy;
    return date;
}

$.validator.addMethod('requiredifdependencyvalue', function (value, element, params) {
    var alloweddpProp = params.dependencyproperty;
    if (alloweddpProp.indexOf("|") >= 0) {
        var dpProps = alloweddpProp.split("|");
        var numberProp = 0;

        for (var j = 0, len = dpProps.length; j < len; j++) {
            var currentdpvalue = $('select[name="' + dpProps[j] + '"]').val() || $('input[name="' + dpProps[j] + '"]').val();

            var alloweddpvalue = params.dependencyvalue;

            if (alloweddpvalue.indexOf("|") >= 0) {
                var dpValues = alloweddpvalue.split("|");
                var number = 0;
                for (var i = 0, len = dpValues.length; i < len; i++) {
                    var alvalue = dpValues[i];
                    if (currentdpvalue === alvalue && (value === null || value === '')) {
                        number = 1;
                    }
                }
                if (number === 1) {
                    numberProp = 1;
                }
                else {
                    numberProp = 0;
                }
            }
            else {
                if (currentdpvalue === alloweddpvalue && (value === null || value === '')) {
                    numberProp = 1;
                }
                else
                    numberProp = 0;
            }
        }
        if (numberProp === 1) {
            return false;
        }
        else {
            return true;
        }
    }
    else {
        if ($('#' + params.dependencyproperty).is(':checkbox')) {
            var currentdpvalue = $('#' + params.dependencyproperty).is(":checked");
            currentdpvalue = currentdpvalue.toString();
        }
        else {
            var currentdpvalue = $('select[name="' + params.dependencyproperty + '"]').val() || $('input[name="' + params.dependencyproperty + '"]').val();
        }

        var alloweddpvalue = params.dependencyvalue;
        if (alloweddpvalue.indexOf("|") >= 0) {
            var dpValues = alloweddpvalue.split("|");
            var number = 0;
            for (var i = 0, len = dpValues.length; i < len; i++) {
                var alvalue = dpValues[i];
                if (currentdpvalue == alvalue && (value == null || value === '')) {
                    number = 1;
                }
            }
            if (number === 1) {
                return false;
            }
            else {
                return true;
            }
        }
        else {
            if (currentdpvalue === alloweddpvalue && (value == null || value === '')) {
                return false;
            }
            else
                return true;
        }
    }
}, '');

jQuery.validator.unobtrusive.adapters.add("requiredifdependencyvalue", ["dependencyproperty", "dependencyvalue"],
    function (options) {
        options.rules['requiredifdependencyvalue'] = {
            dependencyproperty: options.params.dependencyproperty,
            dependencyvalue: options.params.dependencyvalue,
        };
        options.messages['requiredifdependencyvalue'] = options.message;
    }
);

//File extension validation
jQuery.validator.unobtrusive.adapters.add('fileextensions', ['fileextensions'], function (options) {
    var params = {
        fileextensions: options.params.fileextensions.split(',')
    };

    options.rules['fileextensions'] = params;
    if (options.message) {
        options.messages['fileextensions'] = options.message;
    }
});

jQuery.validator.addMethod("fileextensions", function (value, element, param) {
    var extension = getFileExtension(value);
    var validExtension = $.inArray(extension, param.fileextensions) !== -1;
    if (validExtension || value === "") {
        return true;
    }
    else {
        return false;
    }
});

function getFileExtension(fileName) {
    var extension = (/[.]/.exec(fileName)) ? /[^.]+$/.exec(fileName) : undefined;
    if (extension != undefined) {
        return extension[0];
    }
    return extension;
};

//parsing the unobtrusive attributes when we get content via ajax
$(document).ajaxComplete(function () {
    $.validator.unobtrusive.parse(document);
    //by default jquery.validate 1.9 doesn't validate hidden inputs
    //if ($.validator) $.validator.setDefaults({
    //    ignore: []
    //});
});

$.validator.methods.date = function (value, element) {
    try { jQuery.datepicker.parseDate(shortdatetimeformatValidation, value); return true; }
    catch (e) { return false; }
};

(function ($) {
    $.validator.unobtrusive.parseDynamicContent = function (selector) {
        //use the normal unobstrusive.parse method
        $.validator.unobtrusive.parse(selector);

        //get the relevant form
        var form = $(selector).first().closest('form');

        //get the collections of unobstrusive validators, and jquery validators
        //and compare the two
        var unobtrusiveValidation = form.data('unobtrusiveValidation');
        var validator = form.validate();

        $.each(unobtrusiveValidation.options.rules, function (elname, elrules) {
            if (validator.settings.rules[elname] == undefined) {
                var args = {};
                $.extend(args, elrules);
                args.messages = unobtrusiveValidation.options.messages[elname];
                $('[name="' + elname + '"]').rules("add", args);
            } else {
                $.each(elrules, function (rulename, data) {
                    if (validator.settings.rules[elname][rulename] == undefined) {
                        var args = {};
                        args[rulename] = data;
                        args.messages = unobtrusiveValidation.options.messages[elname][rulename];
                        $('[name="' + elname + '"]').rules("add", args);
                    }
                });
            }
        });
    }
})($);

(function ($, Globalize) {

    // Clone original methods we want to call into
    var originalMethods = {
        min: $.validator.methods.min,
        max: $.validator.methods.max,
        range: $.validator.methods.range
    };

    // Tell the validator that we want numbers parsed using Globalize

    $.validator.methods.number = function (value, element) {
        var val = Globalize.parseFloat(value);
        return this.optional(element) || ($.isNumeric(val));
    };

    // Tell the validator that we want dates parsed using Globalize

    //$.validator.methods.date = function (value, element) {
    //    var val = Globalize.parseDate(value);
    //    return this.optional(element) || (val);
    //};

    // Tell the validator that we want numbers parsed using Globalize, 
    // then call into original implementation with parsed value

    $.validator.methods.min = function (value, element, param) {
        var val = Globalize.parseFloat(value);
        return originalMethods.min.call(this, val, element, param);
    };

    $.validator.methods.max = function (value, element, param) {
        var val = Globalize.parseFloat(value);
        return originalMethods.max.call(this, val, element, param);
    };

    $.validator.methods.range = function (value, element, param) {
        var val = Globalize.parseFloat(value);
        return originalMethods.range.call(this, val, element, param);
    };

}(jQuery, Globalize));


    

