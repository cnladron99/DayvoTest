// Values storage
var data = {
    text: ''
}

var inputText = document.getElementById('inputText');
var hasTyped = document.getElementById('hasTyped');
var needType = document.getElementById('needType');

hasTyped.style.display = 'none';

// Function to wacth changes over storage
var monitor = function (object, property, callback) {
    var value = object[property];
    delete object[property];

    // Recreate the storage property with the new value
    Object.defineProperty(object, property, {
        configurable: false,
        enumerable: false,
        get: function () {
            return value;
        },
        set: function (newValue) {
            value = newValue;

            // Execute callback after values has been set
            callback(newValue);
        }
    });
};

var isConsonant = function (letter) {
    var consonants = 'bcdfghjklmnpqrstvwxyz';
    var consonantsArray = consonants.split('');

    return consonantsArray.indexOf(letter) > -1;
}

var countConsonants = function (text) {
    consonantCounter = 0;

    // Count consonants
    for (const letter of text) {
        if (isConsonant(letter)) {
            consonantCounter++;
        }
    }

    return consonantCounter;
}

// Attach the monitor to text property in data storage
monitor(data, 'text', function (newValue) {
    inputText.value = newValue;

    var typedText = document.getElementById('typedText');
    typedText.textContent = newValue;
});

// Attach input event to refresh values on screen
inputText.addEventListener('input', function () {
    data.text = inputText.value;

    hasTyped.style.display = data.text.length === 0 ? 'none' : 'block';
    needType.style.display = data.text.length === 0 ? 'block' : 'none';

    document.getElementById('totalTextLength').textContent = data.text.length;
    document.getElementById('characterCounter').textContent = data.text.length;

    // Count consonants
    var consonantsCount = countConsonants(data.text);
    var consonantPercentage = 0;

    if (data.text.length > 0) {
        consonantPercentage * 100 / data.text.length;
    }

    document.getElementById('consonantCounter').textContent = consonantsCount;
    document.getElementById('consonantPercentage').textContent = consonantPercentage.toFixed(2);
});