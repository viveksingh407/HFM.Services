$(document).on('click', '.EditTransaction', function () {
    var editButton = $(this);
    var closestParentTable = editButton.closest('table');
    var closestParentRow = editButton.closest('table').closest('tr');

    closestParentTable.find('.UpdateTransaction').removeClass('hide');
    closestParentTable.find('.DeleteTransaction').removeClass('hide');
    closestParentTable.find('.CancelTransaction').removeClass('hide');
    editButton.addClass('hide');

    closestParentRow.find('.transactionReadOnlyDetails').addClass('hide');
    closestParentRow.find('.transactionEditDetails').removeClass('hide');
})

$(document).on('click', '.CancelTransaction', function () {
    hideButtons($(this));
})

$(document).on('click', '.AddTransaction', function () {
    hideButtons($(this));
})

$(document).on('click', '.UpdateTransaction', function () {
    var parentRow = $(this).closest('table').closest('tr');
    var transactionDetailId = parentRow.find(".tdTransactionDetailId").html().trim();
    var transactionDetailName = parentRow.find(".txtTransactionDetailName").val();
    var updateButton = $(this);

    var url = 'update';

    $.ajax({
        type: "POST",
        url: url,
        data: { 'TransactionDetailsId': transactionDetailId, 'TransactionDetailsName': transactionDetailName },
        success: function (data) {
            hideButtons(updateButton);
            alert('Update successful.');
            $('.dvTransactionDetails').html(data);
        },
        failure: function (jqXHR, textStatus, error) {
            console.log("Post error: " + error);
        }
    });
})

$(document).on('click', '.DeleteTransaction', function () {
    alert('Deleting..');
})

function hideButtons(clickedButton) {
    var closestParentTable = clickedButton.closest('table');
    var closestParentRow = clickedButton.closest('table').closest('tr');

    closestParentTable.find('.UpdateTransaction').addClass('hide');
    closestParentTable.find('.DeleteTransaction').addClass('hide');
    closestParentTable.find('.CancelTransaction').addClass('hide');
    closestParentTable.find('.EditTransaction').removeClass('hide');

    closestParentRow.find('.transactionReadOnlyDetails').removeClass('hide');
    closestParentRow.find('.transactionEditDetails').addClass('hide');

    closestParentRow.find('.txtTransactionDetailName').val('');
}