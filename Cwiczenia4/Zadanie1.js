document.addEventListener("DOMContentLoaded", function () {
    const container = document.getElementById('multiplicationTable');
    const message = document.getElementById('message');

    let n = parseInt(prompt("Podaj liczbê n (5 <= n <= 20):", "10"));
    if (isNaN(n) || n < 5 || n > 20) {
        n = 10;
        message.textContent = "Podano niepoprawne dane, wiêc przyjêto n = 10.";
    }

    function getRandomNumbers(count) {
        const min = 1;
        const max = 99;
        const numbers = new Set();
        while (numbers.size < count) {
            numbers.add(Math.floor(Math.random() * (max - min + 1)) + min);
        }
        return Array.from(numbers);
    }

    const numbers = getRandomNumbers(n);

    const table = document.createElement("table");

    const headerRow = document.createElement("tr");
    const emptyHeader = document.createElement("th");
    headerRow.appendChild(emptyHeader);

    numbers.forEach(number => {
        const headerCell = document.createElement("th");
        headerCell.textContent = number;
        headerRow.appendChild(headerCell);
    });
    table.appendChild(headerRow);

    numbers.forEach(rowNumber => {
        const row = document.createElement("tr");

        const rowHeader = document.createElement("th");
        rowHeader.textContent = rowNumber;
        row.appendChild(rowHeader);

        numbers.forEach(colNumber => {
            const cell = document.createElement("td");
            const result = rowNumber * colNumber;
            cell.textContent = result;
            cell.className = result % 2 == 0 ? "even" : "odd";
            row.appendChild(cell);
        });

        table.appendChild(row);
    });

    container.appendChild(table);
});
