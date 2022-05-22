import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CommonService {

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

  getAllCompanies() {
    return this._http.get<any>(`${environment.apiUrl}Common/GetAllCompanies`)
  }
}
