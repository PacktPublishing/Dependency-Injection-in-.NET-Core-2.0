// File ES6Code.ts 
var ES6Code;
(function (ES6Code) {
    function foo() { console.log("Foo executed"); }
    ES6Code.foo = foo;
    var Timer = (function () {
        function Timer(todaysDate) {
            this.localTime = todaysDate.toTimeString();
            this.currentDate = todaysDate.toLocaleDateString();
        }
        return Timer;
    }());
    ES6Code.Timer = Timer;
})(ES6Code || (ES6Code = {}));
//# sourceMappingURL=es6code.js.map