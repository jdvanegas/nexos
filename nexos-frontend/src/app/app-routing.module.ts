import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DoctorsListComponent } from './compontents/doctors-list/doctors-list.component';
import { DoctorsCreateComponent } from './compontents/doctors-create/doctors-create.component';
import { PatientsListComponent } from './compontents/patients-list/patients-list.component';
import { PatientsCreateComponent } from './compontents/patients-create/patients-create.component';


const routes: Routes = [
  {path: 'doctores', children: [
    {path: '', component: DoctorsListComponent},
    {path: 'crear', component: DoctorsCreateComponent},
  ]},
  {path: 'pacientes', children: [
    {path: '', component: PatientsListComponent},
    {path: 'crear', component: PatientsCreateComponent},
  ]},
  {path: 'paciente/:id', component: PatientsCreateComponent},
  {path: '', pathMatch: 'full', redirectTo: 'doctores'},
  {path: '**', redirectTo: 'doctores'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
