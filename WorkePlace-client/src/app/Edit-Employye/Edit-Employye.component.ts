import { Component, OnInit, Input } from '@angular/core';
import { inject } from '@angular/core/testing';
import { Employee } from '../_models/Employee';
import { ActivatedRoute, Router } from '@angular/router';
import { Manager } from '../_models/Manager';
import { EmployeeService } from '../services/employee.service';
import { ManagerService } from '../services/Manager.service';
import { HttpClient } from '@angular/common/http';
import { error, debug, debuglog } from 'util';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Edit-Employye',
  templateUrl: './Edit-Employye.component.html',
  styleUrls: ['./Edit-Employye.component.css']
})
export class EditEmployyeComponent implements OnInit {
model: any = {};
Employeeid: number;
managers: Manager;
Employee: Employee;
selected;



constructor(private rout: Router, private route: ActivatedRoute, private em: EmployeeService, private man: ManagerService) { }

  ngOnInit() {

   this.Employeeid = Number( this.route.snapshot.params.id);
   this.getemployee(this.Employeeid);
   this.getmanagers();


  }

 
  ADD() {
    this.model.managerID = this.selected;
    
    this.em.Update(this.model).subscribe( () => {  this.rout.navigate(['Empployess_list']);}, error => {alert(error)});
  }
  getemployee(id: number) {

    this.em.getallemployee(id).subscribe(data => { this.model = data, this.selected = data.managerID;}, error => {alert(error)});

  }
  getmanagers() {

    this.man.getallmanagers().subscribe(data => {this.managers = data;},error => {alert(error)});
  }

  selectChangeHandler(event: any) {

    this.selected = event.target.value;

  }
  numberOnly(event): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }

}
