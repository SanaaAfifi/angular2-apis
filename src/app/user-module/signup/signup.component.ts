import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {JokesService} from '../../services/jokes.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css'],
  providers: [JokesService]
})
export class SignupComponent implements OnInit {

  constructor(public router: Router , public jokesService : JokesService  ) { }

  ngOnInit() {
  }

   signup(event, username, password,confirmPassword,userImage) {
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

  login(event) {
    event.preventDefault();
    this.router.navigate(['login']);
  }

}
