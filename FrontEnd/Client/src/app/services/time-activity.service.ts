import { Injectable } from "@angular/core";
import { Http, Headers, RequestOptions } from "@angular/http";
import { map } from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})
export class TimeActivityService {

  constructor(private http: Http) { }

  public InsertTimeActivity(ITIMAC) {
    let fullUrl = "http://localhost:56758/api/v1/timeactivity";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(fullUrl, JSON.stringify(ITIMAC), options).pipe(map(result => result.json()));
  }


  public DeleteTimeActivity(TIMEACTIVITECODE) {
    let fullUrl = "http://localhost:56758/api/v1/timeactivity/" + TIMEACTIVITECODE;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.delete(fullUrl, options).pipe(map(result => result.json()));
  }


  public Updatetimeactivity(UPTIMEACT) {
    let fullUrl = "http://localhost:56758/api/v1/timeactivity";
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.put(fullUrl, JSON.stringify(UPTIMEACT), options).pipe(map(result => result.json()));
  }


  public SearchCodeTimeActivity(SEARTIMACTCOD) {
    let fullUrl = "http://localhost:56758/api/v1/timeactivity/searcodetimact/" + SEARTIMACTCOD;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));
  }


  public GetTimeActivityAll() {
    let fullUrl = 'http://localhost:56758/api/v1/timeactivity';
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));;
  }


  public SearchTimActiIdUse(SEARTIMACTIDUS) {
    let fullUrl = "http://localhost:56758/api/v1/timeactivity/seariduser/" + SEARTIMACTIDUS;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));
  }

  public SearchActivityCode(SEARTACTICOD) {
    let fullUrl = "http://localhost:56758/api/v1/timeactivity/searacticod/" + SEARTACTICOD;
    let headers = new Headers({ "Content-Type": "application/json" });
    let options = new RequestOptions({ headers: headers });
    return this.http.get(fullUrl, options).pipe(map(result => result.json()));
  }
}
