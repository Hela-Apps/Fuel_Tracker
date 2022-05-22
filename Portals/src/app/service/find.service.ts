import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FindService {

  constructor(private _http: HttpClient) { }

  getAllCategories() {
    return this._http.get<any>(`${environment.apiUrl}Common/GetAllCategories`)
  }
  getAllGetAllDistricts() {
    return this._http.get<any>(`${environment.apiUrl}Common/GetAllDistricts`)
  }

  getAllCitiesByDistrictId(id : number) {
    return this._http.get<any>(`${environment.apiUrl}Common/GetAllCitiesbyDistrictId?districtId=`+ id)
  }
}
