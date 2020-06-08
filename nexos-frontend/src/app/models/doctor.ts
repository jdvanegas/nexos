import { Hospital } from './hospital';

export interface Doctor {
    "id": number,
    "name": string,
    "lastName": string,
    "credentialNumber": string,
    "hospital": Hospital
}
