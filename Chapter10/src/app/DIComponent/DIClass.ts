import { Injectable } from "@angular/Core";

@Injectable()
export class DIClass {
    public DIProperty: string = "This block comes from an injected Class";
    public DIPicture: string = 'http://lorempixel.com/320/200/business';
}