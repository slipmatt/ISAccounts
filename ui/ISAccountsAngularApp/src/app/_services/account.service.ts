import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AccountModel, ResponseModel} from 'src/app/core/Models/core.models';
import {Observable, ObservableLike} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  readonly APIUrl = 'https://localhost:44348';
    constructor(private http:HttpClient) { }
  
    addAccount(val:AccountModel): Observable<ResponseModel>{
      return this.http.post<ResponseModel>(this.APIUrl+'/Accounts/CreateAccount',val);
    }
  
    getAccountByPersonCode(val:number): Observable<ResponseModel>{
      return this.http.get<ResponseModel>(this.APIUrl+'/Accounts/GetAccountByPersonCode/'+val);
    }
  
    closeAccount(val:number): Observable<ResponseModel>{
      return this.http.get<ResponseModel>(this.APIUrl+'/Accounts/CloseAccountByCode/'+val);
    }
  }
