$(document).ready(function() {

    $.extend(true, $.fn.dataTable.defaults, {
        "sDom": 'T<"clear">lfrtip',
        "oTableTools": {
            "aButtons": [
                "copy",
                "print",
                {
                    "sExtends": "collection",
                    "sButtonText": "Save",
                    "aButtons": ["csv", "xls", "pdf"]
                }
            ]
        }
    });
});
