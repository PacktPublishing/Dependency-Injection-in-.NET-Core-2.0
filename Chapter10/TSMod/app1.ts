/* Implicit module (goes to the global namespace)
// It appears as part of the window object */
class ClassA {
    private x = "The String";
    public y = 4;
};
var ca = new ClassA();

// Internal module (named)
module MyClasses {
    export class ClassA {
        private x = "The String";
        public y = 4;
    };
    var ic = new ClassA();
}
//ic.y = 9;  // Not recognized

var c = new MyClasses.ClassA();
console.log(c.y); // Logs 4 in the console window.
