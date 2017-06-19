import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http'
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/do'

@Injectable()
export class JokesService {


      JokesServiceUrl;


constructor(
        private httpService: Http) {
        this.JokesServiceUrl ='http://10.10.15.159/Jokes.WebApi/api/PostedJokes'
    }


    getAllJokes(): Observable<any> {
        var headers = new Headers();
        let url = this.JokesServiceUrl;
        return this.httpService.get(url , { headers: headers }).
        map(response => response.json()).do(data => JSON.stringify(data));
    }

     getByUserID(UserID: string): Observable<any> {
        var headers = new Headers();
        let url = this.JokesServiceUrl;
        return this.httpService.get(url+ '/GetByUser/'+UserID, { headers: headers }).
        map(response => response.json()).do(data => JSON.stringify(data));
    }

      hide(jokeID: number): Observable<any> {
        var headers = new Headers();
        let url = this.JokesServiceUrl;
        return this.httpService.post(url+ '/Hide/'+jokeID, { headers: headers }).
        map(response => response.json()).do(data => JSON.stringify(data));
    }


      addNewJoke(joke:any): Observable<any> {
        var headers = new Headers();
         let body = joke;
        let url = this.JokesServiceUrl;
        return this.httpService.post(url,body, { headers: headers}).
        map(response => response.json()).do(data => JSON.stringify(data));
    }

    vote(jokeId:number,up : boolean): Observable<any> {
        var headers = new Headers();
        let url = this.JokesServiceUrl;
        return this.httpService.post(url+'/Vote/'+jokeId+'/'+up, { headers: headers}).
        map(response => response.json()).do(data => JSON.stringify(data));
    }


}
