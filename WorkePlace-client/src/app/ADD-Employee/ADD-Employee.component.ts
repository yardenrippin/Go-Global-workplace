import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../_models/Employee';
import { EmployeeService } from '../services/employee.service';
import { Manager } from '../_models/Manager';
import { ManagerService } from '../services/Manager.service';

import { Router } from '@angular/router';

@Component({
  selector: 'app-ADD-Employee',
  templateUrl: './ADD-Employee.component.html',
  styleUrls: ['./ADD-Employee.component.css']
})
export class ADDEmployeeComponent implements OnInit {
Employee: Employee;
model: any = {};
managers: Manager [];
selected:number;

  constructor( private router:Router,  private mansrevice: ManagerService , private emservice: EmployeeService, private http: HttpClient) { }

  ngOnInit() {
    this.mansrevice.getallmanagers().subscribe(data=> {this.managers=data,this.model.managerid=this.managers[0].id;} ,error => {alert('cnot get data')});
    
  }

  selectChangeHandler (event: any) {
    
    this.selected = event.target.value;

  }

  ADD() {
    
 
    this.emservice.Add(this.model).subscribe(x=>{this.router.navigate(['Empployess_list']);} ,error=>{alert("data not savde")});
   
  }

  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }
}
