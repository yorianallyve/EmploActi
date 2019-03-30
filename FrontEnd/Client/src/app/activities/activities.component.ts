import { Component, OnInit } from '@angular/core';
import { ActivitiesService } from '../services/activities.service';
import { Activities } from '../models/activities';

@Component({
  selector: 'app-activities',
  templateUrl: './activities.component.html',
  styleUrls: ['./activities.component.css'],
  providers: [ActivitiesService]
})
export class ActivitiesComponent implements OnInit {
  IdUser = 1;
  public activities: Activities = new Activities(0, "", 0);
  NotificationStatus: boolean = false;
  TypeNotification: string = "success";
  TextNotification: string = "Primera notificación";
  public active = true;
  public submitted = false;

  constructor(private activitiesservice: ActivitiesService) { }

  ngOnInit() {
  }

  onClickInsertActivities() {
    this.activities.IdUser=this.IdUser;
    this.activitiesservice.InsertActivities(this.activities).subscribe(
      result => {
        console.log(result);
        if (result.CodeError == 0) {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "success";
        } else {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  onClickUpdateActivities() {
    this.activities.IdUser=this.IdUser;
    this.activitiesservice.UpdateActivities(this.activities).subscribe(
      result => {
        console.log(result);
        if (result.CodeError == 0) {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "success";
        } else {
          this.NotificationStatus = true;
          this.TextNotification = result.DescriptionError;
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  onClickSearchCodeActivities() {
    this.activitiesservice.SearchCodeActivities(this.activities.ActivitiesCode).subscribe(
      result => {
        console.log(result);
        if (result != null) {
          this.activities.ActivitiesCode = result.ActivitiesCode;
          this.activities.NameActivities = result.NameActivities;
          this.activities.IdUser = result.IdUser;  
        } else {
          this.NotificationStatus = true;
          this.TextNotification = "La actividad no existe";
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  onClickGetProductAll() {
    this.activitiesservice.GetActivitiesAll().subscribe(
      result => {
        console.log(result);
        if (result != null) {
          this.activities.ActivitiesCode = result.ActivitiesCode;
          this.activities.NameActivities = result.NameActivities;
          this.activities.IdUser = result.IdUser;
        } else {
          this.NotificationStatus = true;
          this.TextNotification = "La actividad no existe";
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  OnClickCleanActivities() {
    this.activities = {
      ActivitiesCode: 0,
      NameActivities: "",
      IdUser:0     
    };
  }

  closeAlert() {
    this.NotificationStatus = !this.NotificationStatus;
  }
}
