import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ActivitiesComponent } from './activities/activities.component';
import { TimeActivityComponent } from './time-activity/time-activity.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';



const routes: Routes = [
  {path: 'activities', component: ActivitiesComponent},
  {path: 'timeactivities', component: TimeActivityComponent},
  {path: 'user', component: UserComponent},
  {path: 'login', component: LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
