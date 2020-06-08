import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { Doctor } from '../models/doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  URL_DOCTORLIST = environment.url_doctorList

  constructor(
    private http: HttpClient
  ) { }


  getDoctors(){
    return this.http.get<Doctor[]>(this.URL_DOCTORLIST)
  }

  createDoctor(body){
    return this.http.post<any>(this.URL_DOCTORLIST, body)
  }

}
