import {Routes} from '@angular/router';
import { Empployess_listComponent } from './Empployess_list/Empployess_list.component';
import { ManagersComponent } from './managers/managers.component';
import { EditEmployyeComponent } from './Edit-Employye/Edit-Employye.component';
import { ADDEmployeeComponent } from './ADD-Employee/ADD-Employee.component';
import { AddManagerComponent } from './Add-Manager/Add-Manager.component';


export const appRoutes: Routes = [

{path : 'Empployess_list', component : Empployess_listComponent },
{path : 'Managers', component : ManagersComponent },
{path : 'Edit-Employye/:id', component : EditEmployyeComponent },
{path : 'ADD-Employye', component : ADDEmployeeComponent  },
{path : 'AddManager', component : AddManagerComponent  }


]
