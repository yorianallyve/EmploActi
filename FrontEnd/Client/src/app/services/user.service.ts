import { Injectable } from "@angular/core";
import { Http, Headers, RequestOptions } from "@angular/http";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: Http) { }

  public InsertUser(IUSER) {
    let fullUrl = "http://localhost:56758/api/v1/user";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(fullUrl, JSON.stringify(IUSER), options).pipe(map(result => result.json()));
  }


  public UpdateUser(UPUSER) {
    let fullUrl = "http://localhost:56758/api/v1/user";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.put(fullUrl, JSON.stringify(UPUSER), options).pipe(map(result => result.json()));
  }


  public SearchIdUser(SEARIDUSE) {
    let fullUrl = "http://localhost:56758/api/v1/user/seariduser/" + SEARIDUSE;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));
  }


  public GetUserAll() {
    let fullUrl = 'http://localhost:56758/api/v1/user';
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));;
  }


  public ValidatioUserPassword(USERNAME, PASSWORD) {
    let fullUrl = "http://localhost:56758/api/v1/user/login/" + USERNAME + PASSWORD;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));
  }
}
