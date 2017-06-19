import { Routes } from '@angular/router';
import { JokesComponent } from './jokes/jokes.component';
import { AuthGuard } from './guards/auth.guard';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';


export const routes: Routes =[
    { path: '', component: HomeComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
  { path: 'jokes', component: JokesComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];
