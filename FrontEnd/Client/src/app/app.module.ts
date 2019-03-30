import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import {ActivitiesService} from './services/activities.service';
import {TimeActivityService} from './services/time-activity.service';
import {UserService} from './services/user.service';
import { ActivitiesComponent } from './activities/activities.component';
import { TimeActivityComponent } from './time-activity/time-activity.component';
import { UserComponent } from './user/user.component';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    ActivitiesComponent,
    TimeActivityComponent,
    UserComponent,
    NavbarComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule.forRoot(),
    FormsModule,
    HttpModule,
  ],
  providers: [
    ActivitiesService,
    TimeActivityService,
    UserService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
