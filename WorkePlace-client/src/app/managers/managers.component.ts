import { Component, OnInit } from '@angular/core';
import { Employee } from '../_models/Employee';
import { ManagerService } from '../services/Manager.service';
import { Manager } from '../_models/Manager';
import { runInThisContext } from 'vm';
import { error } from 'protractor';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-managers',
  templateUrl: './managers.component.html',
  styleUrls: ['./managers.component.css']
})
export class ManagersComponent implements OnInit {
  Empployess: Employee [];
  Managers: Manager [];
  manegername: string;
  emid;
  constructor(private man: ManagerService, private route: Router) { }

  ngOnInit() {
    this.man.getallmanagers().subscribe(data=>{this.Managers=data},error=> {alert('cant get data')});

  }
  getemploye(id: number) {
this.man.getaem(id).subscribe(data => {this.Empployess = data }, error=> {alert('cant get data')});
  }
  selectChangeHandler(event: any){
   this.emid=event.target.value;
  }
  gotoaddmanager(){
this.route.navigate(['AddManager']);
  }
}
