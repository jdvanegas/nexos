import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { Hospital } from '../models/hospital';

@Injectable({
  providedIn: 'root'
})
export class HospitalService {

  URL_HOSPITALLIST = environment.url_hospitalList

  constructor(
    private http: HttpClient
  ) { }


  getHospitals(){
    return this.http.get<Hospital[]>(this.URL_HOSPITALLIST);
  }

}
