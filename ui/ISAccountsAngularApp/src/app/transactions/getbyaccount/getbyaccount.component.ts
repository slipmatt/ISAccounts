import { Component, OnInit, Input } from '@angular/core';
import { TransactionService} from 'src/app/_services/transaction.service';
import { ActivatedRoute } from '@angular/router';
import {TransactionModel} from 'src/app/core/Models/core.models';
@Component({
  selector: 'app-getbyaccount',
  templateUrl: './getbyaccount.component.html',
  styleUrls: ['./getbyaccount.component.css']
})
export class GetbyaccountComponent implements OnInit {
  account_id: any;
  constructor(private actRoute: ActivatedRoute, private service: TransactionService) { }
  TransactionList: Array<TransactionModel>=[];
  PageOfTransactionList: Array<TransactionModel>=[];
  ModalTitle:string="";
  ActivateAddEditTransactionComp:boolean=false;
  transaction:any;
  ngOnInit(): void {
    this.actRoute.paramMap.subscribe(params => {
      this.account_id = params.get('id');
    });
    this.refreshTransactionsList();
  }

  refreshTransactionsList(){
    this.service.getTransactionsPerAccount(this.account_id).subscribe(data=>{
      console.log(data.returnObject);
      this.TransactionList=data.returnObject;
    })
  }

  
  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.PageOfTransactionList = pageOfItems;
}

  addTransactionClick(){
    this.transaction={
      code:0,
      accountCode:Number(this.account_id),
      transactionDate:new Date(),
      captureDate:new Date(), 
      Amount:0,
      Description:""
    }
    this.ModalTitle = "Add Transaction";
    this.ActivateAddEditTransactionComp=true;
  }

  
  closeClick() {
    this.ActivateAddEditTransactionComp=false;
    this.refreshTransactionsList();
  }
}