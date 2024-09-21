function updateQuantity(tableId, productId, newQuantity) {
    if (newQuantity < 1) {
        alert("Ürün adedi en az 1 olmalıdır.");
        return
    }
    $.ajax({
        url: "https://localhost:7015/Table/UpdateItemTest",
        type: 'POST',
        data: {
            tableId: tableId,
            productId: productId,
            newQuantity: newQuantity
        },
        headers: {
            'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
        },
        success: function (response) {
            window.location.reload();
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            alert("Ürün güncellenirken bir hata oluştu.");
        }
    });
}
function deleteItem(tableId, productId) {
    $.ajax({
        url: "https://localhost:7015/Table/DeleteItemTest",
        type: 'POST',
        data: {
            tableId: tableId,
            productId: productId,
            __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
        },
        success: function (response) {
            window.location.reload();
        },
        error: function (xhr, status, error) {
            console.error('Error:', error);
            console.error('Response Text:', xhr.responseText);
            alert("Ürün silinirken bir hata oluştu.");
        }
    });
}