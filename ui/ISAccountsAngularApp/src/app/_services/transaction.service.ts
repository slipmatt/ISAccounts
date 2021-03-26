import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ResponseModel, TransactionModel} from 'src/app/core/Models/core.models';
import {Observable, ObservableLike} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  readonly APIUrl = 'https://localhost:44348';
    constructor(private http:HttpClient) { }
  
    addTransaction(val:TransactionModel): Observable<ResponseModel>{
      return this.http.post<ResponseModel>(this.APIUrl+'/Transactions/CreateTransaction',val);
    }
  
    getTransactionByCode(val:number): Observable<ResponseModel>{
      return this.http.get<ResponseModel>(this.APIUrl+'/Transactions/GetTransactionByCode/'+val);
    }
  
    getTransactionsPerAccount(val:number): Observable<ResponseModel>{
      return this.http.get<ResponseModel>(this.APIUrl+'/Transactions/GetTransactionsByAccountCode/'+val);
    }
  }