import { Component, OnInit, Input } from '@angular/core';
import {AccountService} from 'src/app/_services/account.service';
import { from } from 'rxjs';

@Component({
  selector: 'acc-app-add-edit',
  templateUrl: './acc-add-edit.component.html',
  styleUrls: ['./acc-add-edit.component.css']
})
export class AccountAddEditComponent implements OnInit {

  constructor(private service: AccountService) { }

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
            code: Number(this.Code),
            personCode: Number(this.PersonCode),
            accountNumber: this.AccountNumber,
            balance:0,
            active:true 
          }
          console.log(val);
  this.service.addAccount(val).subscribe(res=>{
    alert(res.userInterfaceMessage.toString())
  });
        
  }
}
