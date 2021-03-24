import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import { from } from 'rxjs';
import { DatePipe } from '@angular/common'

@Component({
  selector: 'trans-app-add-edit',
  templateUrl: './trans-add-edit.component.html',
  styleUrls: ['./trans-add-edit.component.css']
})
export class TransAddEditComponent implements OnInit {

  public minDate: Date = new Date ("05/07/2017");

  public maxDate: Date = new Date();

  public dateValue: Date = new Date();

  constructor(public datepipe: DatePipe, private service: SharedService) { }

  @Input() transaction:any;
  Code:number=0;
  AccountCode:number=0;
  TransactionDate:Date=new Date();
  CaptureDate:Date=new Date();
  Amount:number=0;
  Description:string=""
  ngOnInit(): void {
    this.Code = this.transaction.code;
    this.AccountCode = this.transaction.accountCode;
    this.TransactionDate = this.transaction.transactionDate;
    this.CaptureDate = this.transaction.captureDate;
    this.Amount = this.transaction.Amount;
    this.Description = this.transaction.description;


  }

  addTransaction(){
  var val = {
            Code: this.Code,
            AccountCode: Number(this.AccountCode),
            TransactionDate: this.datepipe.transform(this.TransactionDate, 'yyyy-MM-dd'),
            CaptureDate:this.datepipe.transform(this.CaptureDate, 'yyyy-MM-dd'),
            Amount:Number(this.Amount),
            Description:this.Description,
          }
          console.log(val);
  this.service.addTransaction(val).subscribe(res=>{
    alert(res.userInterfaceMessage.toString())
  });
        
  }
}
