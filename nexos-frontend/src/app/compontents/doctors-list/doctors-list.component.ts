import { Component, OnInit } from '@angular/core';
import { DoctorService } from '../../services/doctor.service'
import { Doctor } from 'src/app/models/doctor';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrls: ['./doctors-list.component.scss']
})
export class DoctorsListComponent implements OnInit {

  doctorsList: Doctor[] = [];

  constructor(
    private doctorService: DoctorService
  ) {
    this.getDoctorList();
   }

  ngOnInit(): void {
  }

  getDoctorList(){
    this.doctorService.getDoctors().subscribe(
      (res: Doctor[])=>{
        this.doctorsList = res
    },err=>{
      console.log(err)
    })
  }

}
