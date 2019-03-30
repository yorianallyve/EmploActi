import { Component, OnInit } from "@angular/core";
import * as moment from "moment";
import { TimeActivityService } from '../services/time-activity.service';
import { TimeActivity } from '../models/time-activity';
import { ActivitiesService } from '../services/activities.service';
import { Activities } from '../models/activities';


@Component({
  selector: 'app-time-activity',
  templateUrl: './time-activity.component.html',
  styleUrls: ['./time-activity.component.css'],
  providers: [TimeActivityService, ActivitiesService]
})
export class TimeActivityComponent implements OnInit {
  IdUser = 1;
  public ltsactivities: Activities[];
  public ltstimeact: TimeActivity[] = [];
  public timeactivity: TimeActivity = new TimeActivity(0, 0, "", 0, 0, "");
  NotificationStatus: boolean = false;
  TypeNotification: string = "success";
  TextNotification: string = "Primera notificación";
  public active = true;
  public submitted = false;

  constructor(private timeactivyservice: TimeActivityService,
    private activitiesservices: ActivitiesService
  ) { }

  ngOnInit() {
    this.getactivities();
  }

  getactivities() {
    this.activitiesservices.GetActivitiesByUser(this.IdUser).subscribe(result => {
      this.ltsactivities = result;
      console.log(this.ltsactivities);
    }),
      error => console.error(error);
  }

  onClickAddList() {
    this.timeactivity.IdUser = this.IdUser;
    this.timeactivyservice.InsertTimeActivity(this.timeactivity).subscribe(result => {
      if (result.CodeError == 0) {
        this.NotificationStatus = true;
        this.TextNotification = result.DescriptionError;
        this.TypeNotification = "success";
        this.onChangeActivity(this.timeactivity.ActivitiesCode);
      } else {
        this.NotificationStatus = true;
        this.TextNotification = result.DescriptionError;
        this.TypeNotification = "danger";
      }
    }),
      error => console.error(error);
  }

  // cambia
  onChangeActivity(ActivitiesCode) {  

    this.timeactivyservice.SearchActivityCode(ActivitiesCode).subscribe(result => {
      this.ltstimeact = result;
    }),
      error => console.error(error);

  }

  //borrar un registro del detalle
  onClickDeteleActivitytime(TIMEACTIVITECODE) {
    this.timeactivyservice.DeleteTimeActivity(TIMEACTIVITECODE).subscribe(result => {
      if (result.CodeError == 0) {
        this.NotificationStatus = true;
        this.TextNotification = result.DescriptionError;
        this.TypeNotification = "success";
        this.onChangeActivity(this.timeactivity.ActivitiesCode);
      } else {
        this.NotificationStatus = true;
        this.TextNotification = result.DescriptionError;
        this.TypeNotification = "danger";
      }

    }),
      error => console.error(error);
  }


  //cerrar notificación
  closeAlert() {
    this.NotificationStatus = !this.NotificationStatus;
  }
}
