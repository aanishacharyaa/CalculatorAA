// indexedDB.js

// Open a connection to the IndexedDB
var request = indexedDB.open('CalculatorDB', 1);

var db;

// Handle the onupgradeneeded event to create object stores
request.onupgradeneeded = function (event) {
    db = event.target.result;
    db.createObjectStore('calculations', { autoIncrement: true });
};

request.onsuccess = function (event) {
    db = event.target.result;
};

request.onerror = function (event) {
    console.error("IndexedDB error:", event.target.error);
};


function storeCalculation(expression, result) {
    var transaction = db.transaction(['calculations'], 'readwrite');
    var objectStore = transaction.objectStore('calculations');

    var calculation = {
        expression: expression,
        result: result
    };

    var request = objectStore.add(calculation);

    request.onsuccess = function (event) {
        console.log("Calculation stored in IndexedDB");
    };

    request.onerror = function (event) {
        console.error("Error storing calculation in IndexedDB:", event.target.error);
    };
}


function displayStoredCalculations() {
    var transaction = db.transaction(['calculations'], 'readonly');
    var objectStore = transaction.objectStore('calculations');

    var request = objectStore.getAll();

    request.onsuccess = function (event) {
        var calculations = event.target.result;
        var calculationsList = document.getElementById('calculations-list');

        calculationsList.innerHTML = ''; // Clear the list

        calculations.forEach(function (calculation) {
            var li = document.createElement('li');
            li.textContent = `Expression: ${calculation.expression}, Result: ${calculation.result}`;
            calculationsList.appendChild(li);
        });
    };

    request.onerror = function (event) {
        console.error("Error retrieving calculations from IndexedDB:", event.target.error);
    };
}


// Call the displayStoredCalculations function when the page loads
window.onload = displayStoredCalculations;