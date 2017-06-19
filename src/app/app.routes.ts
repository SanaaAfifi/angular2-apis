import { Routes } from '@angular/router';
import { JokesComponent } from './jokes/jokes.component';

import { HomeComponent } from './home/home.component';
import { ResgistrationComponent } from './resgistration/resgistration.component';

import { LoginComponent } from './user-module/login/login.component';
import { SignupComponent } from './user-module/signup/signup.component';

import { AuthGuard} from './services/auth.service';

// Define which component should be loaded based on the current URL
export const routes: Routes = [
  { path: '',       component: LoginComponent , pathMatch: 'full'  },
  { path: 'login',  component: LoginComponent , pathMatch: 'full' },
  { path: 'signup', component: SignupComponent, pathMatch: 'full'  },
  // { path: 'home',   component: JokesComponent, canActivate: [AuthGuard], pathMatch: 'full'  },
  { path: 'home',   component: HomeComponent, pathMatch: 'full'  },
  { path: 'profile',   component:JokesComponent, pathMatch: 'full'  },

  { path: '**',     component: LoginComponent, pathMatch: 'full'  },
];