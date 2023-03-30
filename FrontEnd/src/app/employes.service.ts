import { Employe } from './employe';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployesService {

  constructor(private httpClient: HttpClient ) { }


  GetEmployes():Observable<any>
  {
    return this.httpClient.get<any>("https://localhost:44374/api/Employe/getEmploye")
  }

  saveEmployes(newemp:Employe):Observable<Employe>
  {
    return this.httpClient.post<Employe>("https://localhost:44374/api/Employe/saveEmploye",newemp)
  }

  updateemploye(upemp:Employe):Observable<Employe>
  {
    return this.httpClient.put<Employe>("https://localhost:44374/api/Employe/updateEmploye",upemp)
  }

  Delete(Id:Number):Observable<any>
  {
    return this.httpClient.delete<any>("https://localhost:44374/api/Employe/DeleteEmploye?id="+Id)
  }

  
}
