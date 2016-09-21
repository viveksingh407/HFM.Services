$("#dailyPurchaseItemName").autocomplete({
    source: function (request, response) {

        var url = 'purchase/getItems';
        $.ajax({
            type: "Get",
            url: url,
            data: { 'query': request.term },
            success: function (data) {
                response($.map(data, function (data, key) {
                    return {
                        label: data.Value,
                        value: data.Key
                    };
                }));
            },
            failure: function (jqXHR, textStatus, error) {
                console.log("Post error: " + error);
            }
        });
    },
    select: function (event, ui) {
        $('#hdnDailyPurchaseItemId').val(ui.item.value);
        $('#dailyPurchaseItemName').val(ui.item.label);
        $('#dailyPurchasePrice').focus();
        event.preventDefault();
    },
    focus: function(event, ui) {
        event.preventDefault();
        $('#hdnDailyPurchaseItemId').val(ui.item.value);
        $('#dailyPurchaseItemName').val(ui.item.label);
    },
    minLength: 1,
    classes: {
        "ui-autocomplete": "highlight"
    }
});

$(document).ready(function () {
    $('#dailyPurchaseDate').val(function () {
        var now = new Date();
        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);

        var today = now.getFullYear() + "-" + (month) + "-" + (day);

        return today;
    });
})

$('#btnDailyPurchaseItem').click(function () {
    var itemId = $("#hdnDailyPurchaseItemId").val();
    var itemName = $("#dailyPurchaseItemName").val();
    var price = $("#dailyPurchasePrice").val();
    var quantity = $("#dailyPurchaseQuantity").val();
    var purchaseDate = $("#dailyPurchaseDate").val();

    var url = 'dailytransactions/adddailytransaction';

    $.ajax({
        type: "POST",
        url: url,
        data: { 
            'PurchasedItemId': itemId,
            'PurchasedItemName': itemName,
            'Price': price,
            'Quntity': quantity,
            'PurchaseDate': purchaseDate,
        },
        success: function (data) {
            alert("Success");
            $('#dailyTransactions').html(data);
        },
        failure: function (jqXHR, textStatus, error) {
            console.log("Post error: " + error);
        }
    });
})