import { Component } from '@angular/core';
import { DIClass } from "./DIComponent/DIClass";

@Component({
  selector: 'app-root',
  providers: [DIClass],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'First demo in Angular 4!';
  subtitle: string = "";
  fotosource : string = "";
  constructor(injectedValues: DIClass) {
    this.subtitle = injectedValues.DIProperty;
    this.fotosource = injectedValues.DIPicture;
  }
  
}
