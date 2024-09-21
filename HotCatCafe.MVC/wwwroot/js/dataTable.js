function sortTable(columnIndex) {
    var table = document.getElementById("orderDetailTable");
    var rows = Array.from(table.tBodies[0].rows);
    var isAscending = table.getAttribute("data-sort-asc") === "true";
    table.setAttribute("data-sort-asc", !isAscending);

    rows.sort(function (rowA, rowB) {
        var cellA = rowA.cells[columnIndex].innerText;
        var cellB = rowB.cells[columnIndex].innerText;

        if (columnIndex === 2 || columnIndex === 4) {  // Fiyat ve Toplam Fiyat sütunları için
            cellA = parseFloat(cellA.replace(/[^0-9.-]/g, ''));
            cellB = parseFloat(cellB.replace(/[^0-9.-]/g, ''));
            return isAscending
                ? cellA - cellB
                : cellB - cellA;
        } else if (columnIndex === 3) {  // Sipariş Tarihi sütunu için
            return isAscending
                ? new Date(cellA) - new Date(cellB)
                : new Date(cellB) - new Date(cellA);
        } else {  // Diğer sütunlar için
            return isAscending
                ? cellA.localeCompare(cellB)
                : cellB.localeCompare(cellA);
        }
    });

    // Tablodaki sıralanmış satırları güncelle
    rows.forEach(function (row) {
        table.tBodies[0].appendChild(row);
    });

    // İkonları güncelle
    updateSortIndicators(columnIndex, isAscending);
}

function updateSortIndicators(sortedColumnIndex, isAscending) {
    var headers = document.querySelectorAll("#orderDetailTable th");
    headers.forEach(function (header, index) {
        header.classList.remove("ascending", "descending");
        if (index === sortedColumnIndex) {
            header.classList.add(isAscending ? "ascending" : "descending");
        }
    });
}

document.addEventListener('DOMContentLoaded', function () {
    function sortTable(columnIndex) {
        const table = document.querySelector("#orderDetailTable");
        const tbody = table.querySelector("tbody");
        const rows = Array.from(tbody.querySelectorAll("tr"));
        const th = table.querySelectorAll("th")[columnIndex];
        const isAscending = th.classList.contains("asc");
        const sortOrder = isAscending ? -1 : 1;

        rows.sort((a, b) => {
            const aText = a.children[columnIndex].innerText.replace(/[^0-9.-]+/g, '');
            const bText = b.children[columnIndex].innerText.replace(/[^0-9.-]+/g, '');

            if (!isNaN(aText) && !isNaN(bText)) {
                return (parseFloat(aText) - parseFloat(bText)) * sortOrder;
            }
            return aText.localeCompare(bText) * sortOrder;
        });

        rows.forEach(row => tbody.appendChild(row));
        table.querySelectorAll("th").forEach(th => th.classList.remove("asc", "desc"));
        th.classList.add(isAscending ? "desc" : "asc");
    }

    document.querySelectorAll("#orderDetailTable th").forEach((th, index) => {
        th.addEventListener("click", () => sortTable(index));
    });
});

