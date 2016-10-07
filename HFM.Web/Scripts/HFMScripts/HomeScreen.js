$('#formHomeScreen').ready(function () {
    var url = 'bankstatements/getstatements';
    var str = '';

    $.ajax({
        type: "GET",
        url: url,
        success: function (data) {
            $.each($.parseJSON(data), function (i, item) {
                str += "<tr><td>" + item["Amount"] + "</td>" +
                "<td>" + item["BalanceAmount"] + "</td>" +
                "<td>" + item["BankAccountTypeId"] + "</td>" +
                "<td>" + item["BankAccountTypeName"] + "</td>" +
                "<td>" + item["BankStatementId"] + "</td>" +
                "<td>" + item["PaymentDate"] + "</td>" +
                "<td>" + item["PostingDate"] + "</td>" +
                "<td>" + item["TransactionDate"] + "</td>" +
                "<td>" + item["TransactionDescription"] + "</td>" +
                "<td>" + item["TransactionNumber"] + "</td><tr>"
            });

            var tableHeader = "<tr><th class=hide> BankStatementId </th> <th class=hide> BankAccountTypeId </th> <th> Bank Name </th> <th> Transaction Date </th> <th> Payment Date </th> <th> Posting Date </th> <th> Transaction Description </th> <th> Transaction Number </th> <th> Amount </th> <th> Balance Amount </th> <th> StoreName </th> </tr>";

            var table = tableHeader + str;

            $('#tblStatements').html(table);
        },
        failure: function (jqXHR, textStatus, error) {
            console.log("Post error: " + error);
        }
    });
})