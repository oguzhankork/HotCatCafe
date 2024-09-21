﻿let ccNumberInput = document.querySelector('.cc-number-input'),
    ccNumberPattern = /^\d{0,16}$/g,
    ccNumberSeparator = " ",
    ccNumberInputOldValue,
    ccNumberInputOldCursor,

    ccExpiryInput = document.querySelector('.cc-expiry-input'),
    ccExpiryPattern = /^\d{0,4}$/g,
    ccExpirySeparator = "/",
    ccExpiryInputOldValue,
    ccExpiryInputOldCursor,

    ccCVCInput = document.querySelector('.cc-cvc-input'),
    ccCVCPattern = /^\d{0,3}$/g,
    ccCVCInputOldValue,
    ccCVCInputOldCursor,

    mask = (value, limit, separator) => {
        var output = [];
        for (let i = 0; i < value.length; i++) {
            if (i !== 0 && i % limit === 0) {
                output.push(separator);
            }
            output.push(value[i]);
        }
        return output.join("");
    },
    unmask = (value) => value.replace(/[^\d]/g, ''),
    checkSeparator = (position, interval) => Math.floor(position / (interval + 1)),

    ccNumberInputKeyDownHandler = (e) => {
        let el = e.target;
        ccNumberInputOldValue = el.value;
        ccNumberInputOldCursor = el.selectionEnd;
    },
    ccNumberInputInputHandler = (e) => {
        let el = e.target,
            newValue = unmask(el.value),
            newCursorPosition;

        if (newValue.match(ccNumberPattern)) {
            newValue = mask(newValue, 4, ccNumberSeparator);

            newCursorPosition =
                ccNumberInputOldCursor - checkSeparator(ccNumberInputOldCursor, 4) +
                checkSeparator(ccNumberInputOldCursor + (newValue.length - ccNumberInputOldValue.length), 4) +
                (unmask(newValue).length - unmask(ccNumberInputOldValue).length);

            el.value = (newValue !== "") ? newValue : "";
        } else {
            el.value = ccNumberInputOldValue;
            newCursorPosition = ccNumberInputOldCursor;
        }

        el.setSelectionRange(newCursorPosition, newCursorPosition);
        highlightCC(el.value);
    },
    highlightCC = (ccValue) => {
        let ccCardType = '',
            ccCardTypePatterns = {
                amex: /^3/,
                visa: /^4/,
                mastercard: /^5/,
                disc: /^6/,
                genric: /(^1|^2|^7|^8|^9|^0)/,
            };

        for (const cardType in ccCardTypePatterns) {
            if (ccCardTypePatterns[cardType].test(ccValue)) {
                ccCardType = cardType;
                break;
            }
        }

        let activeCC = document.querySelector('.cc-types__img--active'),
            newActiveCC = document.querySelector(`.cc-types__img--${ccCardType}`);

        if (activeCC) activeCC.classList.remove('cc-types__img--active');
        if (newActiveCC) newActiveCC.classList.add('cc-types__img--active');
    },
    ccExpiryInputKeyDownHandler = (e) => {
        let el = e.target;
        ccExpiryInputOldValue = el.value;
        ccExpiryInputOldCursor = el.selectionEnd;
    },
    ccExpiryInputInputHandler = (e) => {
        let el = e.target,
            newValue = el.value;

        newValue = unmask(newValue);
        if (newValue.match(ccExpiryPattern)) {
            newValue = mask(newValue, 2, ccExpirySeparator);
            el.value = newValue;
        } else {
            el.value = ccExpiryInputOldValue;
        }
    },
    ccCVCInputKeyDownHandler = (e) => {
        let el = e.target;
        ccCVCInputOldValue = el.value;
        ccCVCInputOldCursor = el.selectionEnd;
    },
    ccCVCInputInputHandler = (e) => {
        let el = e.target,
            newValue = unmask(el.value);

        if (newValue.match(ccCVCPattern)) {
            el.value = newValue; // No masking needed for CVV
        } else {
            el.value = ccCVCInputOldValue;
        }
    };

// Event Listeners
ccNumberInput.addEventListener('keydown', ccNumberInputKeyDownHandler);
ccNumberInput.addEventListener('input', ccNumberInputInputHandler);

ccExpiryInput.addEventListener('keydown', ccExpiryInputKeyDownHandler);
ccExpiryInput.addEventListener('input', ccExpiryInputInputHandler);

ccCVCInput.addEventListener('keydown', ccCVCInputKeyDownHandler);
ccCVCInput.addEventListener('input', ccCVCInputInputHandler);