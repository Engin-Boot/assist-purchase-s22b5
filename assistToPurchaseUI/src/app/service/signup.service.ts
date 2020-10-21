import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
providedIn: 'root'
})
export class SignupService {

 constructor(private http:HttpClient) { }
public getList():Observable<any>{
return this.http.get("http://localhost:53951/api/products/");
}

 public submitList(data):Observable<any>{
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
return this.http.post<any>("http://localhost:53951/api/Signup/",data,httpOptions);
}
}