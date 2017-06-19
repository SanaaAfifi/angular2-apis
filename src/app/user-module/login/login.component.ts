import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {JokesService} from '../../services/jokes.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers:[JokesService ]
})
export class LoginComponent implements OnInit {

 constructor(public router: Router , public jokesService : JokesService  ) { }

   ngOnInit() {
  }
  login(event, username, password) {
    event.preventDefault();

    // to add this to the service
    /*
    let body = JSON.stringify({ username, password });
    this.http.post('http://localhost:3001/sessions/create', body, { headers: contentHeaders })
      .subscribe(
        response => {
          localStorage.setItem('id_token', response.json().id_token);
          this.router.navigate(['home']);
        },
        error => {
          alert(error.text());
          console.log(error.text());
        }
      );*/
    }
     signup(event) {
    event.preventDefault();
    this.router.navigate(['signup']);
  }

     register(event, username,Email, password,confirmPassword) {
    event.preventDefault();
    // add this to user service

   /* let body = JSON.stringify({ username, password,confirmPassword,userImage });
    this.http.post('http://localhost:3001/users', body, { headers: "to update this" })
      .subscribe(
        response => {
          localStorage.setItem('id_token', response.json().id_token);
          this.router.navigate(['home']);
        },
        error => {
          alert(error.text());
          console.log(error.text());
        }
      );*/
  }


}

  