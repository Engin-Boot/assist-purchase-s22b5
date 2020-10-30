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
public getList2():Observable<any>{
  return this.http.get("http://localhost:53951/api/InterestedCustomer/");
  }

  public getListWeight(a,b):Observable<any>{
    return this.http.get("http://localhost:53951/api/chatapp/?MinWeight="+a+"&MaxWeight="+b);
    }

    public getListScreenSize(a,b):Observable<any>{
      return this.http.get("http://localhost:53951/api/chatapp/?MinScreenSize="+a+"&MaxScreenSize="+b);
      }
      public getListScreenWeight(a,b,c,d,e):Observable<any>{
        return this.http.get("http://localhost:53951/api/chatapp/?MinWeight="+a+"&MaxWeight="+b+"&MinScreenSize="+c+"&MaxScreenSize="+d+"&IsPortable="+e);
        }
        public getListPortable(a):Observable<any>{
          return this.http.get("http://localhost:53951/api/chatapp/?IsPortable="+a);
          }

 public submitList(data):Observable<any>{
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
return this.http.post<any>("http://localhost:53951/api/Signup/",data,httpOptions);
}
public addProduct(data):Observable<any>{
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
return this.http.post<any>("http://localhost:53951/api/products/",data,httpOptions);
}

public updateProduct(data):Observable<any>{
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
return this.http.put<any>("http://localhost:53951/api/products/",data,httpOptions);
}

public submitList2(data):Observable<any>{
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
return this.http.post<any>("http://localhost:53951/api/Signup/validate",data,httpOptions);
}
public submitList3(data):Observable<any>{
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
return this.http.delete<any>("http://localhost:53951/api/products/"+data,httpOptions);
}
public submitList4(data):Observable<any>{
  const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) }; 
return this.http.post<any>("http://localhost:53951/api/InterestedCustomer/",data,httpOptions);
}
}