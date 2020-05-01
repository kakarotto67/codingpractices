import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-snow-forecast',
  templateUrl: './snow-forecast.component.html'
})

export class SnowForecastComponent {

  private locationNameFromUi: string;
  private locationIdFromUi: number;

  private baseUrl = environment.snowForecastCenterBaseUrl;

  public forecastDetails: ForecastDetails;

  public enableGetForecastByLocationNameBtn = false;
  public enableGetForecastByLocationIdBtn = false;
  public showForecastDetails = false;

  constructor(private http: HttpClient) { }

  // Get forecast by location name
  public getForecastForLocationByName() {
    return this.http.get<ForecastDetails>(this.baseUrl + this.locationNameFromUi).subscribe(result => {
      this.forecastDetails = result;
      this.showForecastDetails = result ? true : false;
    }, error => {
        console.error(error);
        this.showForecastDetails = false;
    });
  }

  // Get forecast by location id
  public getForecastForLocationById() {
    return this.http.get<ForecastDetails>(this.baseUrl + this.locationIdFromUi).subscribe(result => {
      this.forecastDetails = result;
      this.showForecastDetails = result ? true : false;
    }, error => {
      console.error(error);
      this.showForecastDetails = false;
    });
  }

  public bindLocationNameFromUi(event: any) {
    var targetValue = event.target.value;
    this.locationNameFromUi = targetValue;
    this.enableGetForecastByLocationNameBtn = targetValue ? true : false;
  }

  public bindLocationIdFromUi(event: any) {
    var targetValue = event.target.value;
    this.locationIdFromUi = targetValue;
    this.enableGetForecastByLocationIdBtn = targetValue ? true : false;
  }
}

interface ForecastDetails {
  locationName: string;
  shortDesc: string;
  longDesc: string;
  temperature: number;
  windSpeed: number;
  cloudsLevel: number;
}
