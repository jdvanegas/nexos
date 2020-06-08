import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material'
import { HttpClientModule } from '@angular/common/http'
import { ReactiveFormsModule } from '@angular/forms'

import { AppComponent } from './app.component';
import { NavigationComponent } from './compontents/navigation/navigation.component';
import { DoctorsListComponent } from './compontents/doctors-list/doctors-list.component';
import { DoctorsCreateComponent } from './compontents/doctors-create/doctors-create.component';
import { PatientsListComponent } from './compontents/patients-list/patients-list.component';
import { PatientsCreateComponent } from './compontents/patients-create/patients-create.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    DoctorsListComponent,
    DoctorsCreateComponent,
    PatientsListComponent,
    PatientsCreateComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
