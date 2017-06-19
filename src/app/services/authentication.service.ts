import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

import { AppConfig } from '../app.config';

@Injectable()
export class AuthenticationService {
    constructor(private http: Http, private config: AppConfig) { }
 login(username: string, password: string) {
        return this.http.post(this.config.sapiUrl+'/Token', JSON.stringify({ username: username, password: password ,grant_type:"password"}))
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let user = response.json();
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem(this.config.TokenKey, JSON.stringify(user));
                }
 
                return user;
            });
    }
 
    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem(this.config.TokenKey);
    }

//     login(email: string, password: string) {
//         let body = "username=" + email + "&password=" + password + "&grant_type=password";

//         let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' });
//         let options = new RequestOptions({ headers: headers });

//         return this.http.post(this.config.apiUrl + '/Token', body, options)
//             .map((response: Response) => {
//                 // login successful if there's a jwt token in the response
//                 let user = response.json();
//                 if (user && user.token) {
//                     // store user details and jwt token in local storage to keep user logged in between page refreshes
//                     localStorage.setItem(this.config.TokenKey, JSON.stringify(user));
//                 }
//             });
//     }
    
//   login3(email: string, password: string)  {
//     let body = "username=" + email + "&password=" + password + "&grant_type=password";

//     this.http.post(this.config.sapiUrl+'/Token', body)
//       .map(res => res.json())
//       .subscribe(
//         // We're assuming the response will be an object
//         // with the JWT on an id_token key
//         data => localStorage.setItem('id_token', data.id_token),
//         error => console.log(error)
//       );
//   }
//     login2(username: string, password: string) {
//         return this.http.post(this.config.sapiUrl + '/Token', { username: username, password: password })
//             .map((response: Response) => {
//                 // login successful if there's a jwt token in the response
//                 let user = response.json();
//                 if (user && user.token) {
//                     // store user details and jwt token in local storage to keep user logged in between page refreshes
//                     localStorage.setItem(this.config.TokenKey, JSON.stringify(user));
//                 }
//             });
//     }
 
//  public signin(username: string, password: string): Observable<any> {  
  
//         // Token endpoint & params.  
//         let tokenEndpoint: string = this.config.apiUrl+"/api/Token"
//         let params: any = {   
//             grant_type: "password",  
//             username: username,  
//             password: password,  
//         };  
//         let body: string = params;  
//         let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });  
//         let options = new RequestOptions({ headers:headers });  
//         return this.http.post(tokenEndpoint, body,options)  
//             .map((response: Response) => {  
  
//                 let user = response.json();
//                 if (user && user.token) {
//                     // Stores access token & refresh token.  
//                     localStorage.setItem(this.config.TokenKey, JSON.stringify(user));
//                 } 
//             }).catch((error: any) => {  
//                 return Observable.throw(error);  
//             });  
  
//     }  
//     logout() {
//         // remove user from local storage to log user out
//         localStorage.removeItem(this.config.TokenKey);
//     }
}