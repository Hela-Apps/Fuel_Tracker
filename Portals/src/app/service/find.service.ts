import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class FindService {

  constructor(private _http: HttpClient) { }

  fuelSearch(categoryId: number,cityId : number  ){
    return this._http.get<any>(`${environment.apiUrl}Station/FuelSearch?categoryId=${categoryId}&cityId=${cityId}`)
  }
 
}
