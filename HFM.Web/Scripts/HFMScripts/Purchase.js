$("#txtItemName").autocomplete({
    source: function (request, response) {

        var url = 'purchase/getItems';
        $.ajax({
            type: "Get",
            url: url,
            data: { 'query': request.term },
            success: function (data) {
                response(data);
            },
            failure: function (jqXHR, textStatus, error) {
                console.log("Post error: " + error);
            }
        });
    },
    minLength: 1,
    classes: {
        "ui-autocomplete": "highlight"
    }
});

$("#btnAddItem").click(function () {
    //var url = 'purchase/getcategoryfromsubcategory';
    var url = 'purchase/gesubcategoryfromitemid';
    //$.get(url, { 'subCategoryId': 1 }).done(function (data) {
    $.get(url, { 'itemId': 1 }).done(function (data) {
        response(data);
    });
});