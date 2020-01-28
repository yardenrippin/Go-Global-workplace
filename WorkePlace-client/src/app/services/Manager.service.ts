import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import {  Manager } from '../_models/Manager';
import { Observable } from 'rxjs';
import { Employee } from '../_models/Employee';

@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getallmanagers() : Observable<any>   {
    
    return this.http.get< Manager>(this.baseUrl + 'Managers');
  }
  getaem(id: number): Observable<any>   {
return this.http.get<Employee>(this.baseUrl + 'Managers/employe?id=' + id);
  }
  Add (Manager: Manager ) {
    return this.http.post(this.baseUrl + 'Managers/Add' , Manager);
  }
 
}
