$('.EditTransaction').click(function () {
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

$('.CancelTransaction').click(function () {
    hideButtons($(this));
})

$('.UpdateTransaction').click(function () {
    var parentRow = $(this).closest('table').closest('tr');
    var transactionDetailId = parentRow.find(".tdTransactionDetailId").html().trim();
    var transactionDetailName = parentRow.find(".txtTransactionDetailName").val();

    var url = 'update';

    $.ajax({
        type: "POST",
        url: url,
        data: { 'TransactionDetailsId': transactionDetailId, 'TransactionDetailsName': transactionDetailName },
        success: function (html) {
            hideButtons($(this));
            alert('Update successful.')
        },
        failure: function (html) {
            alert('Update failed.')
        }
    });
})

$('.DeleteTransaction').click(function () {
    alert('Deleting..');
})

function hideButtons(clickedButton) {
    var closestParentTable = clickedButton.closest('table');
    var closestParentRow = clickedButton.closest('table').closest('tr');

    closestParentTable.find('.UpdateTransaction').addClass('hide');
    closestParentTable.find('.DeleteTransaction').addClass('hide');
    closestParentTable.find('.EditTransaction').removeClass('hide');
    clickedButton.addClass('hide');

    closestParentRow.find('.transactionReadOnlyDetails').removeClass('hide');
    closestParentRow.find('.transactionEditDetails').addClass('hide');

    closestParentRow.find('.txtTransactionDetailName').val('');
}