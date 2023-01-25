import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/core/models/employee';
import { EmployeeService } from 'src/core/services/employee.service';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.scss']
})
export class EmployeeFormComponent implements OnInit {
  public form: FormGroup;
  public submittted = false;
  public id: number;
  public title: string = 'Add Employee';

  constructor(private snackBar: MatSnackBar,
    private activedRoute: ActivatedRoute,
    private route: Router,
    private employeeService: EmployeeService) { }

  ngOnInit() {
    this.buildForm(new Employee());
    let id = this.activedRoute.snapshot.paramMap.get('id');
    if (id !== 'new' && id !== null && id !== undefined) {
      this.title = 'Edit Employee';
      this.id = parseInt(id);
      this.get(this.id);
    }
  }

  private buildForm(model: Employee) {

    this.form = new FormGroup({
      name: new FormControl(model.name),
      birthDate: new FormControl(model.birthDate),
      gender: new FormControl(model.gender),
      email: new FormControl(model.email),
      startDate: new FormControl(model.startDate),
      team: new FormControl(model.team),
      id: new FormControl(model.id)
    });
  }

  public get(id: number){
    this.employeeService.getEmployee(id).subscribe(employee => {
      this.buildForm(employee);
    }, error => {
      console.log(error);
      this.snackBar.open('Failure to load data!', '', {
        duration: 3000,
      });
    });
  }


  public onClickBack(){
    this.route.navigate(['']);
  }

  public save(){
    let employee: Employee = this.form.value;
    employee.gender = parseInt(employee.gender);
    employee.team = parseInt(employee.team);
    if(this.id) {
      employee.id = this.id;
      this.update(employee);
    }
    else {
      this.add(employee);
    }

  }

  add(employee: Employee) {
    this.employeeService.save(employee).subscribe(response => {
      if(response){
        this.snackBar.open('Successful!', '', {
          duration: 3000,
        });
        this.route.navigate(['/']);
      }else{
        this.snackBar.open('Failure to save data!', '', {
          duration: 3000,
        });
      }
    }, error => {
      console.log(error);
      this.snackBar.open('Failure to save data!', '', {
        duration: 3000,
      });
    });
  }

  update(employee: Employee) {
    this.employeeService.update(employee).subscribe(response => {
      if(response){
        this.snackBar.open('Successful!', '', {
          duration: 3000,
        });
        this.route.navigate(['/']);
      }else{
        this.snackBar.open('Failure to save data!', '', {
          duration: 3000,
        });
      }
    }, error => {
      console.log(error);
      this.snackBar.open('Failure to save data!', '', {
        duration: 3000,
      });
    });
  }

}
