import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
  providers: [UserService]
})
export class UserComponent implements OnInit {

  public user: User = new User(0, "", "");
  NotificationStatus: boolean = false;
  TypeNotification: string = "success";
  TextNotification: string = "Primera notificación";
  public active = true;
  public submitted = false;
  constructor(private userservice: UserService) { }

  ngOnInit() {
  }

  onClickInsertUser() {
    this.userservice.InsertUser(this.user).subscribe(
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

  onClickUpdateUser() {

    this.userservice.UpdateUser(this.user).subscribe(
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

  onClickSearchIdUser() {
    this.userservice.SearchIdUser(this.user.IdUser).subscribe(
      result => {
        console.log(result);
        if (result != null) {
          this.user.IdUser = result.IdUser;
          this.user.NameUser = result.NameUser;
          this.user.Password = result.Password;  
        } else {
          this.NotificationStatus = true;
          this.TextNotification = "El usuario no existe";
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  onClickGetUserAll() {
    this.userservice.GetUserAll().subscribe(
      result => {
        console.log(result);
        if (result != null) {
          this.user.IdUser = result.IdUser;
          this.user.NameUser = result.NameUser;
          this.user.Password = result.Password;
        } else {
          this.NotificationStatus = true;
          this.TextNotification = "El usuario no existe";
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  onClickValidatioUserPassword(USERNAME, PASSWORD) {
    this.userservice.ValidatioUserPassword(USERNAME, PASSWORD).subscribe(
      result => {
        console.log(result);
        if (result != null) {
          this.user.IdUser = result.IdUser;
          this.user.NameUser = result.NameUser;
          this.user.Password = result.Password;  
        } else {
          this.NotificationStatus = true;
          this.TextNotification = "El usuario no existe";
          this.TypeNotification = "danger";
        }
      },
      error => console.error(error)
    );
  }

  OnClickCleanUser() {
    this.user = {
      IdUser:0,
      NameUser: "",
      Password: "",    
    };
  }

  closeAlert() {
    this.NotificationStatus = !this.NotificationStatus;
  }
}
