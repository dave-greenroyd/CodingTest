"use strict";


// Please Note: its probably not best practice not to extend the string object to handle this functionality.
// I would consider refactoring this given time. However, I was told to only spend a couple of hours on the 
// on the project so I'm hoping that you are not expecting me to have done so.

if (!String.prototype.capitalise) {
    String.prototype.capitalise = function() {
        return this.charAt(0).toUpperCase() + this.slice(1);
    };
}

if (!String.prototype.camelCaseToSpineCase) {
    String.prototype.camelCaseToSpineCase = function() {
        return this.replace(/([A-Z])/g, '-$1').split(' ').join('-').replace(/--/g, '-').toLowerCase();
    };
}

if (!String.prototype.spineCaseToCamelCase) {
    String.prototype.spineCaseToCamelCase = function() {
        var targetString = this.trim();

        return targetString.split(' ').join('-').replace(/-\w/g, function(m) {
            return m[1].toUpperCase();
        });
    };
}

if (!String.prototype.format) {
    String.prototype.format = function() {
        var args = arguments;
        return this.replace(/{(\d+)}/g, function(match, number) {
            return typeof args[number] !== 'undefined'
                ? args[number]
                : match;
        });
    };
}

if (!String.prototype.trim) {
    String.prototype.trim = function () {
        return this.replace(/^\s+|\s+$/g, '');
    };
}


