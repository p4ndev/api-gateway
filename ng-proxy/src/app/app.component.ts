import { IForecast            } from './entities/forecast.interface';
import { ApiService           } from './services/api.service';
import { Component, isDevMode } from '@angular/core';
import { Observable           } from 'rxjs';

@Component({
  selector: 'app-root',
  template: `
    <h1>Welcome to {{title}}!</h1>
    <p>Dev: {{ dev }}</p>

    <h2>Three random forecast</h2>
    <p>{{ (forecast$ | async) | json }}</p>

    <h2>Total cities</h2>
    <p>ACRE: {{ acreCitiesTotal$ | async }}</p>
    <p>SAO PAULO: {{ saoPauloCitiesTotal$ | async }}</p>
    <p>TOCANTINS: {{ tocantinsCitiesTotal$ | async }}</p>

    <h2>Cities on Acre start by A</h2>
    {{ (acreCitie$ | async) | json }}

    <h2>Cities on Sao Paulo start by B</h2>
    {{ (saoPauloCitie$ | async) | json }}

    <h2>Cities on Tocantins start by C</h2>
    {{ (tocantinsCitie$ | async) | json }}
  `
})
export class AppComponent {
  
  dev       : boolean = false;
  title     : string = 'ng-proxy';
  forecast$ : Observable<Array<IForecast>>;

  acreCitiesTotal$      : Observable<number>;
  saoPauloCitiesTotal$  : Observable<number>;
  tocantinsCitiesTotal$ : Observable<number>;

  acreCitie$      : Observable<Array<string>>;
  saoPauloCitie$  : Observable<Array<string>>;
  tocantinsCitie$ : Observable<Array<string>>;

  constructor(private service : ApiService) {
    
    this.dev                    = isDevMode();
    this.forecast$              = service.threeForecasts();

    this.acreCitiesTotal$       = service.cityTotal("ac");
    this.saoPauloCitiesTotal$   = service.cityTotal("sp");
    this.tocantinsCitiesTotal$  = service.cityTotal("to");

    this.acreCitie$             = service.cityStartsBy("ac", "a");
    this.saoPauloCitie$         = service.cityStartsBy("sp", "b");
    this.tocantinsCitie$        = service.cityStartsBy("to", "c");

    this.service.setUser();
    this.service.signUp();

  }

}
