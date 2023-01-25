import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private baseURL = "https://localhost:44369/api/Employee";


constructor(private httpClient: HttpClient) { }

  public get(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(`${this.baseURL}`);
  }

  public getEmployee(id: number): Observable<Employee> {
    return this.httpClient.get<Employee>(`${this.baseURL}/${id}`);
  }

  public save(employee: Employee) : Observable<Employee> {
    return this.httpClient.post<Employee>(`${this.baseURL}`, employee);
  }

  public update(employee: Employee) : Observable<Employee> {
    return this.httpClient.put<Employee>(`${this.baseURL}`, employee);
  }


  public delete(id: number): Observable<any> {
    return this.httpClient.delete<any>(`${this.baseURL}/${id}`);
  }
}
