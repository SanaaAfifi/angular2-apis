import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { AuthHttp } from 'angular2-jwt';
import {JokesService} from '../services/jokes.service'


@Component({
  selector: 'app-jokes',
  templateUrl: './jokes.component.html',
  styleUrls: ['./jokes.component.css'],
  providers:[JokesService]
})
export class JokesComponent implements OnInit {

  public JokesList = [];
  id : number;

  private newJoke: string = '';

  jwt: string;
  decodedJwt: string;
  response: string;
  api: string;

 /* constructor(private jokesService: JokesService) {
        this.id = 1;
   }*/

  
    constructor( private jokesService: JokesService) {
        this.id = 1;
   // this.jwt = localStorage.getItem('id_token');
    // this.decodedJwt = this.jwt && window.jwt_decode(this.jwt);
  }
    
  ngOnInit() {
        this.getAllJokes()
  }
  getAllJokes ()
  {
        
       this.jokesService.
            getAllJokes().subscribe(result => { this.JokesList = result 
            });   
  }
PostNewJoke ()
{
  var joke : any = {PostedBy : "testUser",Content:this.newJoke,JokeId:this.id ++ }
  
      this.jokesService.
            addNewJoke(joke).subscribe(result => {this.JokesList.unshift(result)}); 
      
      this.JokesList.push(joke)

      this.newJoke ='';
}
  
  VoteUp ( up: boolean)
{
  var joke : any = {PostedBy : "testUser",Content:this.newJoke}
  
      this.jokesService.
            addNewJoke(joke).subscribe(result => {this.JokesList.unshift(result)}); 

      this.newJoke ='';
}

Hide ()
{
  var joke : any = {PostedBy : "testUser",Content:this.newJoke}
  
      this.jokesService.
            addNewJoke(joke).subscribe(result => {this.JokesList.unshift(result)}); 

      this.newJoke ='';
}

}
