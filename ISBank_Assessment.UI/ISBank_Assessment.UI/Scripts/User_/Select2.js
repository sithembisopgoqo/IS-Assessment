function InitializeSelect2Parent() {    

    $('.custom-select').select2({
        width: '100%',
        placeholder: 'Select an option...'
    });

    $('.custom-select').on("change", function (e) {
        $(this).valid()
    })
}

function InitializeSelect2() {

    $('.custom-select').select2({
        dropdownParent: $('#bd-example-modal-lg'),
        width: '100%',
        allowClear: true,
        placeholder: 'Select an option...'
    });

    $('.custom-select').on("change", function (e) {
        $(this).valid()
    })

}

function InitializeCustomSelect2(ModalId) {

    $('.custom-select').select2({
        dropdownParent: $('#' + ModalId),
        width: '100%',
        allowClear: true,
        placeholder: 'Select an option...'
    });

    $('.custom-select').on("change", function (e) {
        $(this).valid()
    })

}


