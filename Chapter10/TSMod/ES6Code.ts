// File ES6Code.ts 
module ES6Code {
    export function foo() { console.log("Foo executed"); }

    export class Timer {
        localTime: string;
        currentDate: string;
        constructor( todaysDate:Date ) {
            this.localTime = todaysDate.toTimeString();
            this.currentDate = todaysDate.toLocaleDateString();
        }
    }
}