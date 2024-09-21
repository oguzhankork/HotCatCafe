function updateQuantity(tableId, productId, newQuantity) {
    $.ajax({
        type: "POST",
        url: "https://localhost:7015/Table/UpdateItem",
        data: { tableId: tableId, productId: productId, newQuantity: newQuantity },
        success: function () {
            location.reload();
        }
    });
}

function deleteItem(tableId, productId) {
    $.ajax({
        type: "POST",
        url: "https://localhost:7015/Table/DeleteItem",
        data: { tableId: tableId, productId: productId },
        success: function () {
            location.reload();
        }
    });
}