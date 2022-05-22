import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Station } from './common.interface';

@Injectable({
  providedIn: 'root'
})
export class InformService {

  constructor(private _http: HttpClient) { }

  
  addStation(data:Station): Observable<any> {
    const addStationUrl = `${environment.apiUrl}Station`
    return this._http.post<any>( addStationUrl, data)
  }
}
