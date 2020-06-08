import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { environment } from '../../environments/environment'
import { Patient } from '../models/patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {

  URL_PATIENSTLIST = environment.url_patientsList

  constructor(
    private http: HttpClient
  ) { }


  getPatients(id = null){
    return this.http.get<Patient[]>(`${this.URL_PATIENSTLIST}/${id ? id : ''}`)
  }

  createPatient(body){
    return this.http.post<any>(this.URL_PATIENSTLIST, body)
  }

  updatePatient(body){
    return this.http.put<any>(this.URL_PATIENSTLIST, body)
  }

}
