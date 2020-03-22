import { Component, OnInit, Query } from '@angular/core';

import { Employee } from '../_models/Employee';
import { EmployeeService } from '../services/employee.service';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Empployess_list',
  templateUrl: './Empployess_list.component.html',
  styleUrls: ['./Empployess_list.component.css']
})
// tslint:disable-next-line: class-name
export class Empployess_listComponent implements OnInit {

  LestName: string;
  FirstName: string;
  IdentityCard: string;
  Empployess: Employee [];



  constructor(private emservice: EmployeeService , private route: Router) { }

  ngOnInit() {
    this.start();
  }

start(){
  this.emservice.getallemployees().subscribe(data =>
    { console.log(data); this.Empployess = data }, error => {alert(error)});
    
}

  SearchByFirstName(firsName: string ) {

this.emservice.search_firstname(firsName).subscribe(data =>
  {this.Empployess = data }, error => {alert(error)});


  }

  SearchBYLestName(lestName: string) {

this.emservice.search_lasrtname(lestName).subscribe(data =>
  {this.Empployess = data },error => {alert(error)});

  }

  SearchBYidentitycard(identitycard: string) {

this.emservice.search_id(identitycard).subscribe(data =>
  {this.Empployess = data }, error => {alert(error)});
  }
 

  navigat_add() {
    this.route.navigate(['/ADD-Employye']);
  }
 
 
alert(id : number) {
  
  if (confirm("Do You Whant Delete This Employee?")) {
    this.emservice.Delete(id).subscribe(success=>{this.start();},error=>{alert(error)});
  } 
}

gotoedit(id: number) {
  
this.route.navigate(['Edit-Employye', id]);
}


}