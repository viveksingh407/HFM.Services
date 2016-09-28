$('#btnStatement').click(function () {
    var accountTypeId = $("#bankAccountTypeId").val();
    var transactionDate = $("#transactionDate").val();
    var paymentDate = $("#paymentDate").val();
    var postingDate = $("#postingDate").val();
    var description = $("#transactionDescription").val();
    var transactionNumber = $("#transactionNumber").val();
    var amount = $("#transactionAmount").val();
    var balanceAmount = $("#totalBalanceAmount").val();

    var url = 'bankstatements/AddStatement';

    $.ajax({
        type: "POST",
        url: url,
        data: {
            'BankAccountTypeId': accountTypeId,
            'TransactionDate': transactionDate,
            'PaymentDate' : paymentDate,
            'PostingDate' : postingDate,
            'TransactionDescription' : description,
            'TransactionNumber' : transactionNumber,
            'Amount' : amount,
            'BalanceAmount' : balanceAmount
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