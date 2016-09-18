$("#txtItemName").autocomplete({
    source: function (request, response) {

        var url = 'getItems';
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

        //jQuery.get("usernames.action", {
        //    query: request.term
        //}, function (data) {
        //    // assuming data is a JavaScript array such as
        //    // ["one@abc.de", "onf@abc.de","ong@abc.de"]
        //    // and not a string
        //    response(data);
        //});
    },
    minLength: 1,
    classes: {
        "ui-autocomplete": "highlight"
    }
});