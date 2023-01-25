import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { Route, Router } from '@angular/router';
import { Employee } from 'src/core/models/employee';
import { EmployeeService } from 'src/core/services/employee.service';
import { EmployeeFormComponent } from './employee-form/employee-form.component';


@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.scss']
})
export class EmployeeComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['name', 'email', 'startDate', 'team', 'action'];
  dataSource: MatTableDataSource<Employee>;

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(
    private service: EmployeeService,
    public dialog: MatDialog,
    private snackBar: MatSnackBar,
    private route: Router) {
  }

  ngOnInit() {

  }

  ngAfterViewInit() {
    this.loadData();
  }

  loadData() {
    this.service.get().subscribe((employees) => {
      this.dataSource = new MatTableDataSource<Employee>(employees);
      this.dataSource.paginator = this.paginator;
    },
    (error) => console.log(error));
  }

  add() {
    this.route.navigate(['/new']);
  }

  public onClickEdit(element: Employee){
    this.route.navigate(['/edit/', element.id]);
  }

  public onClickDelete(element: Employee){
    this.service.delete(element.id).subscribe(retorno => {
      if (retorno.ok) {
        this.snackBar.open('Successful !', '', {
          duration: 3000,
        });
        this.loadData();
      } else {
        this.snackBar.open(retorno.allErros, '', {
          duration: 3000,
        });
      }
    }, error => {
      console.log(error);
      this.snackBar.open('Failure to delete data!', '', {
        duration: 3000,
      });
    })
  }
}
