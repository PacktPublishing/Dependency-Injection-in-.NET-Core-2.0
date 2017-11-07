/* Implicit module (goes to the global namespace)
// It appears as part of the window object */
var ClassA = (function () {
    function ClassA() {
        this.x = "The String";
        this.y = 4;
    }
    return ClassA;
}());
;
var ca = new ClassA();
// Internal module (named)
var MyClasses;
(function (MyClasses) {
    var ClassA = (function () {
        function ClassA() {
            this.x = "The String";
            this.y = 4;
        }
        return ClassA;
    }());
    MyClasses.ClassA = ClassA;
    ;
    var ic = new ClassA();
})(MyClasses || (MyClasses = {}));
//ic.y = 9;  // Not recognized
var c = new MyClasses.ClassA();
console.log(c.y); // Logs 4 in the console window.
//# sourceMappingURL=app1.js.map