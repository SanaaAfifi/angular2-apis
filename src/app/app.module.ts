import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import {RouterModule} from '@angular/router';
import {ImageUploadModule} from 'angular2-image-upload';
import { AppComponent } from './app.component';
import { JokesComponent } from './jokes/jokes.component';

import { AUTH_PROVIDERS } from 'angular2-jwt';

import { AuthGuard } from './services/auth.service';
import { LoginComponent } from './user-module/login/login.component';
import { SignupComponent } from './user-module/signup/signup.component';

import { routes } from './app.routes';
import { HomeComponent } from './home/home.component';


@NgModule({
  declarations: [
    AppComponent,
    JokesComponent,
    LoginComponent,
    SignupComponent,
    HomeComponent
      ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
        ImageUploadModule.forRoot(),
     RouterModule.forRoot(routes, {
      useHash: true
    })
  ],
 // providers: [AuthGuard,   AUTH_PROVIDERS],
  bootstrap: [AppComponent]
})
export class AppModule { }
