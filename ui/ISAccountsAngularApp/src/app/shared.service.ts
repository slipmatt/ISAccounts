import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable, ObservableLike} from 'rxjs';

export interface ResponseModel {
  isSuccess: boolean;
  code: number;
  userInterfaceMessage: string;
  technicalMessage: string;
  returnObject: any[]
}

@Injectable({
  providedIn: 'root'
})
export class SharedService {
readonly APIUrl = 'https://localhost:44348';
  constructor(private http:HttpClient) { }

  getPersonsList(): Observable<ResponseModel>{
    return this.http.get<ResponseModel>(this.APIUrl+'/Person/GetAllPeople');
  }

  getPersonByCode(val:any): Observable<ResponseModel>{
    return this.http.get<ResponseModel>(this.APIUrl+'/Person/GetPersonByCode/'+val);
  }

  addPerson(val:any){
    console.log(val);
    return this.http.post<ResponseModel>(this.APIUrl+'/Person/CreatePerson',val);
  }

  updatePerson(val:any){
    console.log(val);
    return this.http.post<ResponseModel>(this.APIUrl+'/Person/UpdatePerson',val);
  }

  deletePerson(val:any){
    console.log(val);
    return this.http.get<ResponseModel>(this.APIUrl+'/Person/DeletePerson/'+val);
  }

  searchPerson(val:any){
    return this.http.post<ResponseModel>(this.APIUrl+'/Person/SearchPeople',val);
  }

  addAccount(val:any){
    return this.http.post<ResponseModel>(this.APIUrl+'/Accounts/CreateAccount',val);
  }

  getAccountByPersonCode(val:any): Observable<ResponseModel>{
    return this.http.get<ResponseModel>(this.APIUrl+'/Accounts/GetAccountByPersonCode/'+val);
  }

  closeAccount(val:any): Observable<ResponseModel>{
    return this.http.get<ResponseModel>(this.APIUrl+'/Accounts/CloseAccountByCode/'+val);
  }

  addTransaction(val:any){
    return this.http.post<ResponseModel>(this.APIUrl+'/Transactions/CreateTransaction',val);
  }

  getTransactionByCode(val:any): Observable<ResponseModel>{
    return this.http.get<ResponseModel>(this.APIUrl+'/Transactions/GetTransactionByCode/'+val);
  }

  getTransactionsPerAccount(val:any): Observable<ResponseModel>{
    return this.http.get<ResponseModel>(this.APIUrl+'/Transactions/GetTransactionsByAccountCode/'+val);
  }

}
