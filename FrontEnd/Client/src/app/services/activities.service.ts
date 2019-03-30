import { Injectable } from "@angular/core";
import { Http, Headers, RequestOptions } from "@angular/http";
import { map } from "rxjs/operators";


@Injectable({
  providedIn: 'root'
})
export class ActivitiesService {

  constructor(private http: Http) { }

  public InsertActivities(IACT) {
    let fullUrl = "http://localhost:56758/api/v1/activities";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(fullUrl, JSON.stringify(IACT), options).pipe(map(result => result.json()));
  }


  public GetActivitiesAll() {
    let fullUrl = 'http://localhost:56758/api/v1/activities';
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));;
  }


  public UpdateActivities(UPACTI) {
    let fullUrl = "http://localhost:56758/api/v1/activities";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.put(fullUrl, JSON.stringify(UPACTI), options).pipe(map(result => result.json()));
  }


  public SearchCodeActivities(SEARACTCOD) {
    let fullUrl = "http://localhost:56758/api/v1/activities/searcodeact/" + SEARACTCOD;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));
  }

  public GetActivitiesByUser(IDUSER) {
    let fullUrl = 'http://localhost:56758/api/v1/activitiesbyuser/' + IDUSER; 
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));;
  }
}
