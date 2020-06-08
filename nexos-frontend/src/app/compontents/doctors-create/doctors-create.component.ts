import { Component, OnInit } from '@angular/core';
import { HospitalService } from '../../services/hospital.service'
import { DoctorService } from '../../services/doctor.service'
import { Hospital } from 'src/app/models/hospital';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Doctor } from 'src/app/models/doctor';

@Component({
  selector: 'app-doctors-create',
  templateUrl: './doctors-create.component.html',
  styleUrls: ['./doctors-create.component.scss']
})
export class DoctorsCreateComponent implements OnInit {

  createDoctorForm: FormGroup;
  hospitalList: Hospital[] = [];

  constructor(
    private hospitalService: HospitalService,
    private formBuilder: FormBuilder,
    private doctorService: DoctorService
  ) { 

    this.createDoctorForm = formBuilder.group({
      name: ['',
      [
        Validators.required
      ]],
      lastName: ['',
      [
        Validators.required
      ]],
      hospital: ['', 
      [
        Validators.required
      ]],
      credentialNumber: ['',
      [
        Validators.required
      ]]
    })

    this.getHospitalList()
  }

  control(name) {
    return this.createDoctorForm.controls[name];
  }

  ngOnInit(): void {
  }

  getHospitalList(){
    this.hospitalService.getHospitals().subscribe(
      (res: Hospital[])=>{
        this.hospitalList = res
      }, 
      err=> {

      })
  }

  createDoctor(){    
    const form = this.createDoctorForm
    form.markAllAsTouched();
    if(form.valid){
      const body =   {
        name: form.controls['name'].value,
        lastName: form.controls['lastName'].value,
        credentialNumber: form.controls['credentialNumber'].value,
        hospital: {
          id: form.controls['hospital'].value,
        }
      }
      
      this.doctorService.createDoctor(body).subscribe(
        res=>{
          location.reload();
        }, 
        err=>{
          console.log(err)
        })
    }
  }

}