"use strict";
var Person = (function () {
    function Person(name, age) {
        this.Name = name;
        this.Age = age;
    }
    Person.prototype.personData = function () {
        return "Name: " + this.Name + ". Age: " + this.Age;
    };
    return Person;
}());
exports.Person = Person;
//# sourceMappingURL=ExternalModule.js.map