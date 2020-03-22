import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient} from '@angular/common/http';
import { Empployess_listComponent } from '../Empployess_list/Empployess_list.component';
import { Employee } from '../_models/Employee';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }


getallemployees(): Observable<any> {
 
return this.http.get<Employee>(this.baseUrl + 'Employees');
}

getallemployee(id: number): Observable<any> {
 
  return this.http.get<Employee>(this.baseUrl + 'Employees/employee?id='+ id);
  }




Delete(id: number) {

return this.http.get(this.baseUrl + 'Employees/delete?id='+id);
 
}
Add(employee: Employee ): Observable<any> {
  return this.http.post<Employee>(this.baseUrl + 'Employees/Add' , employee);
}

Update(employee: Employee): Observable<any>{

  return this.http.put<Employee>(this.baseUrl + 'Employees/update' , employee);
}
search_firstname(str: string): Observable<any> {
return this.http.get<Employee>(this.baseUrl +'Employees/byfirstname?firstname=' + str);
}
search_lasrtname(str: string): Observable<any> {
  return this.http.get<Employee>(this.baseUrl +'Employees/bylastname?lastname=' + str);
}
search_id(str: string): Observable<any> {
  
  return this.http.get<Employee>(this.baseUrl +'Employees/byid?id=' + str);
}

}
