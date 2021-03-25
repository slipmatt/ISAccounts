import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ResponseModel, SearchModel, PersonModel} from 'src/app/core/Models/core.models';
import {Observable, ObservableLike} from 'rxjs';

@Injectable({
    providedIn: 'root'
  })
export class PersonService {
  readonly APIUrl = 'https://localhost:44348';
    constructor(private http:HttpClient) { }
  
    getPersonsList(): Observable<ResponseModel>{
      return this.http.get<ResponseModel>(this.APIUrl+'/Person/GetAllPeople');
    }
  
    getPersonByCode(val:number): Observable<ResponseModel>{
      return this.http.get<ResponseModel>(this.APIUrl+'/Person/GetPersonByCode/'+val);
    }
  
    addPerson(val:PersonModel){
      console.log(val);
      return this.http.post<ResponseModel>(this.APIUrl+'/Person/CreatePerson',val);
    }
  
    updatePerson(val:PersonModel){
      console.log(val);
      return this.http.post<ResponseModel>(this.APIUrl+'/Person/UpdatePerson',val);
    }
  
    deletePerson(val:number){
      console.log(val);
      return this.http.get<ResponseModel>(this.APIUrl+'/Person/DeletePerson/'+val);
    }
  
    searchPerson(val:SearchModel){
      return this.http.post<ResponseModel>(this.APIUrl+'/Person/SearchPeople',val);
    }
}
  