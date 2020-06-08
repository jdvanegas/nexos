import { Component, OnInit } from '@angular/core';
import { PatientService } from '../../services/patient.service';
import { Patient } from 'src/app/models/patient';

@Component({
  selector: 'app-patients-list',
  templateUrl: './patients-list.component.html',
  styleUrls: ['./patients-list.component.scss'],
})
export class PatientsListComponent implements OnInit {
  patientList: Patient[] = [];

  constructor(private patientService: PatientService) {
    this.getPatientsList();
  }

  ngOnInit(): void {}

  getPatientsList() {
    this.patientService.getPatients().subscribe(
      (res: Patient[]) => {
        this.patientList = res;
      },
      (err) => {
        console.log(err);
      }
    );
  }

  deletePatient(id) {
    this.patientService.deletePatient(id).subscribe(
      (res) => {
        this.getPatientsList();
      },
      (err) => {
        console.log(err);
      }
    );
  }
}
