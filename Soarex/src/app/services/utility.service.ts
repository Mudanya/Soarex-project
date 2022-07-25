import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Service } from '../models/service';
import { Utility } from '../models/utility';

const url:string = "https://localhost:7085/api/settings";
const urlService:string = "https://localhost:7085/api/services";
const httpOptions = {
  "headers": new HttpHeaders({
    "Content-Type":"application/json"
  })
} 
@Injectable({
  providedIn: 'root'
})
export class UtilityService {

  constructor(private http:HttpClient) { }

  getUtilitySettings() : Observable<Utility>
  {
    return this.http.get<Utility>(url);
  }
  getServices() : Observable<Service[]>
  {
    return this.http.get<Service[]>(urlService);
  }

  postUtilitySettings(utilityFormData:FormData) : Observable<void>{
    return this.http.post<void>(url,utilityFormData)
  }

  updateUtilitySettings(utilityFormData:FormData) : Observable<void>{
    return this.http.put<void>(url,utilityFormData)
  }

}
