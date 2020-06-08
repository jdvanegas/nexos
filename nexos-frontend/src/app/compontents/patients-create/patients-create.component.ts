import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { DoctorService } from '../../services/doctor.service'
import { Doctor } from 'src/app/models/doctor';
import { PatientService } from '../../services/patient.service'
import { Router, ActivatedRoute } from '@angular/router'
import { Patient } from 'src/app/models/patient';

@Component({
  selector: 'app-patients-create',
  templateUrl: './patients-create.component.html',
  styleUrls: ['./patients-create.component.scss']
})
export class PatientsCreateComponent implements OnInit {

  patientForm: FormGroup
  doctorsList: Doctor[] = []
  patientData;

  constructor(
    private formBuilder: FormBuilder,
    private doctorService: DoctorService,
    private patientService: PatientService,
    private activeRoute: ActivatedRoute,
    private router: Router
  ) {
    this.patientForm = formBuilder.group({
      name: ['',
      [
        Validators.required
      ]],
      lastName: ['',
      [
        Validators.required
      ]],
      securityNumber: ['',
      [
        Validators.required
      ]],
      postalCode: ['',
      [
        Validators.required
      ]],
      phone: ['',
      [
        Validators.required
      ]],
      doctors: ['',
      [
        Validators.required
      ]]
    })
    this.loadPatientData()
    this.getDoctorsList()
   }

  ngOnInit(): void {
  }

  loadPatientData()
  {
    const patientId = this.activeRoute.snapshot.paramMap.get("id")
    if(patientId){
      this.patientService.getPatients(patientId).subscribe(
        (res: Patient[]) => {
          this.patientData = res;
          const form = this.patientForm
          form.controls['name'].setValue(this.patientData.name);
          form.controls['lastName'].setValue(this.patientData.lastName);
          form.controls['securityNumber'].setValue(this.patientData.securityNumber);
          form.controls['postalCode'].setValue(this.patientData.postalCode);
          form.controls['phone'].setValue(this.patientData.phone);
          form.controls['doctors'].setValue(this.patientData.doctors.map(x => x.id));
        },
        err => {
  
        })
    }
  }

  getDoctorsList(){
    this.doctorService.getDoctors().subscribe(
      (res: Doctor[])=> {
        this.doctorsList = res
      }, 
      err=>{

      })
  }

  control(name) {
    return this.patientForm.controls[name];
  }

  createPatient(){
    const form = this.patientForm
    form.markAllAsTouched();
    if(form.valid){
      const body = {
        id: this.patientData ? this.patientData.id : null,
        name: form.controls['name'].value,
        lastName: form.controls['lastName'].value,
        securityNumber: form.controls['securityNumber'].value,
        postalCode: form.controls['postalCode'].value,
        phone: form.controls['phone'].value,
        doctors: form.controls['doctors'].value.map(x => {
          return {id : x}
        })
      }
      if(this.patientData){
        this.patientService.updatePatient(body).subscribe(
          res=>{
            this.router.navigate(['pacientes'])
          },
          err=>{
            console.log(err)
          })
      }
      else {
        this.patientService.createPatient(body).subscribe(
          res=>{
            console.log(res)
            location.reload();
          },
          err=>{
            console.log(err)
          })
      }
    }
  }

}
