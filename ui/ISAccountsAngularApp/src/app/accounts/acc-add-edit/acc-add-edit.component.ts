import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import { from } from 'rxjs';

@Component({
  selector: 'acc-app-add-edit',
  templateUrl: './acc-add-edit.component.html',
  styleUrls: ['./acc-add-edit.component.css']
})
export class AccountAddEditComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() account:any;
  Code:number=0;
  PersonCode:number=0;
  AccountNumber:string="";
  Balance:number=0;
  Active:boolean=true;
  ngOnInit(): void {
    this.Code = this.account.code;
    this.PersonCode = this.account.personCode;
    this.AccountNumber = this.account.accountNumber;
    this.Balance = this.account.balance;
    this.Active = this.account.active;
  }

  addAccount(){
  var val = {
            Code: this.Code,
            PersonCode: Number(this.PersonCode),
            AccountNumber: this.AccountNumber,
            Balance:0,
            Active:true 
          }
          console.log(val);
  this.service.addAccount(val).subscribe(res=>{
    alert(res.userInterfaceMessage.toString())
  });
        
  }
}
