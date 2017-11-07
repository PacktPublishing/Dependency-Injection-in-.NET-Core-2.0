
export class Person {
    Name: string;
    Age: number;

    constructor(name: string, age: number) {
        this.Name = name;
        this.Age = age;
    }

    personData() {
        return "Name: " + this.Name + ". Age: " + this.Age;
    }
}
