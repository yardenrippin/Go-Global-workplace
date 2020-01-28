import { Component, OnInit } from '@angular/core';
import { Employee } from '../_models/Employee';
import { Manager } from '../_models/Manager';
import { ManagerService } from '../services/Manager.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-Add-Manager',
  templateUrl: './Add-Manager.component.html',
  styleUrls: ['./Add-Manager.component.css']
})
export class AddManagerComponent implements OnInit {


  model: any = {};
  managers: Manager [];
  selected: number;

    constructor( private router: Router,  private mansrevice: ManagerService ) { }

    ngOnInit() {

    }

  ADD() {

    this.mansrevice.Add(this.model).subscribe(x=>{this.router.navigate(['Managers']);} ,error=>{alert("data not savde")});
    }

    numberOnly(event): boolean {
      const charCode = (event.which) ? event.which : event.keyCode;
      if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
      }
      return true;

    }
}
