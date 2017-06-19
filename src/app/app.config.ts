export class AppConfig {
    //49521
     public readonly apiUrl = 'http://localhost:55628';
    public readonly sapiUrl = 'https://localhost:55628';
     public readonly JokesServiceUrl = this.apiUrl+ '/api/PostedJokes';
     public readonly AccountServiceUrl = this.apiUrl+'/api/Account';
    public readonly TokenKey = 'currentUser';
};