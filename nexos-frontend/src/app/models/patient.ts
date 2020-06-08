import { Doctor } from './doctor';

export interface Patient{
    "id": number,
    "name": string,
    "lastName": string,
    "securityNumber": string,
    "postalCode": string,
    "phone": string,
    "doctors": Doctor[]
  }