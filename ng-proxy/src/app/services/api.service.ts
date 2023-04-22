import { IForecast  } from '../entities/forecast.interface';
import { HttpClient, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private User = {
    email     : "email_",
    password  : "123_um#tres"
  };

  constructor(private http : HttpClient) {}

  cityTotal       = (uf : string)                   : Observable<number>            => this.http.get<number>(`/state/${uf}`);
  threeForecasts  = ()                              : Observable<Array<IForecast>>  => this.http.get<Array<IForecast>>("/forecast");
  cityStartsBy    = (uf : string, letter : string)  : Observable<Array<string>>     => this.http.get<Array<string>>(`/state/${uf}/${letter}`);

  setUser() : void {
    this.User.email += new Date().getMilliseconds();
    this.User.email += "@aol.com";
  }

  signUp() : void{
    this.http
      .post<boolean>("/auth", this.User, { observe: "response" })
      .subscribe({
        error     : (err : any) => console.error(err),
        next      : (res : HttpResponse<boolean>) => {
          if(res.body)    console.log("New user created");
          else            console.error("User already created");
        }        
      });
  }

}
