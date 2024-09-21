<script>
    $(document).ready(function () {
        $('#tableSelect').change(function () {
            var selectedTableId = $(this).val();

            if (selectedTableId) {
                // AJAX ile seçilen masanın ürünlerini getir
                $.ajax({
                    url: '@Url.Action("GetProductsByTable", "Home")',
                    type: 'GET',
                    data: { tableId: selectedTableId },
                    success: function (result) {
                        $('#productList').empty();
                        if (result.length > 0) {
                            $.each(result, function (i, product) {
                                $('#productList').append('<li class="list-group-item">' + product.ProductName + ' - ' + product.UnitPrice + ' ₺</li>');
                            });
                        } else {
                            $('#productList').append('<li class="list-group-item">Bu masada ürün yok.</li>');
                        }
                    }
                });
            } else {
                $('#productList').empty();
            }
        });
        });
</script>