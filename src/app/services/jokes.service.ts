import { Injectable } from '@angular/core';
import { Http, Response,RequestOptions, Headers } from '@angular/http'
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/do'
import { AppConfig } from '../app.config';

@Injectable()
export class JokesService {
JokesServiceUrl;
AccountServiceUrl;
constructor(
        private httpService: Http, private config: AppConfig) {
            this.JokesServiceUrl = config.JokesServiceUrl;
        }
// start user section
login(username: string, password: string) {
        return this.httpService.post(this.config.apiUrl + '/users/authenticate', { username: username, password: password })
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let user = response.json();
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('currentUser', JSON.stringify(user));
                }
            });
    }
 
    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
    }
// end user section
    getAllJokes(): Observable<any> {
        var headers = new Headers();
        let url = this.JokesServiceUrl;
        return this.httpService.get(url , this.jwt()).
        map(response => response.json()).do(data => JSON.stringify(data));
    }

     getByUserID(UserID: string): Observable<any> {
        var headers = new Headers();
        let url = this.JokesServiceUrl;
        return this.httpService.get(url+ '/GetByUser/'+UserID, this.jwt()).
        map(response => response.json()).do(data => JSON.stringify(data));
    }

      hide(jokeID: number): Observable<any> {
        var headers = new Headers();
        let url = this.JokesServiceUrl;
        return this.httpService.post(url+ '/Hide/'+jokeID, this.jwt()).
        map(response => response.json()).do(data => JSON.stringify(data));
    }


      addNewJoke(joke:any): Observable<any> {
        var headers = new Headers();
         let body = joke;
        let url = this.JokesServiceUrl;
        return this.httpService.post(url,body, this.jwt()).
        map(response => response.json()).do(data => JSON.stringify(data));
    }

    vote(jokeId:number,up : boolean): Observable<any> {
        var headers = new Headers();
        let url = this.JokesServiceUrl;
        return this.httpService.post(url+'/Vote/'+jokeId+'/'+up, this.jwt()).
        map(response => response.json()).do(data => JSON.stringify(data));
    }
    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(localStorage.getItem(this.config.TokenKey));
        if (currentUser && currentUser.token) {
            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.token });
            return new RequestOptions({ headers: headers });
        }
    }

}
