import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './routes';
import { Empployess_listComponent } from './Empployess_list/Empployess_list.component';
import { ManagersComponent } from './managers/managers.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { EditEmployyeComponent } from './Edit-Employye/Edit-Employye.component';
import { ADDEmployeeComponent } from './ADD-Employee/ADD-Employee.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { AddManagerComponent } from './Add-Manager/Add-Manager.component';
import { ErrorInterceptorProvider } from './services/error.interceptor';




@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      Empployess_listComponent,
      ManagersComponent,
      EditEmployyeComponent,
      ADDEmployeeComponent,
      AddManagerComponent
   ],
   imports: [
      AngularFontAwesomeModule,
      HttpClientModule,
      BrowserModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes)
   ],
   providers: [ErrorInterceptorProvider],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
