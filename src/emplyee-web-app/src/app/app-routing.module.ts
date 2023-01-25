import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeeFormComponent } from './employee/employee-form/employee-form.component';
import { EmployeeComponent } from './employee/employee.component';

const routes: Routes = [
  { path: '', component: EmployeeComponent },
  { path: 'new', component: EmployeeFormComponent },
  { path: 'edit/:id', component: EmployeeFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
