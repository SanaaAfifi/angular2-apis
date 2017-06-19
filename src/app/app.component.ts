import { Component } from '@angular/core';
import {Router} from '@angular/router';
import { AlertComponent } from './alert/alert.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {

constructor(public router: Router) {}

}

