import { Component, OnInit } from '@angular/core';
import {AccountService} from 'src/app/_services/account.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-getbyperson',
  templateUrl: './getbyperson.component.html',
  styleUrls: ['./getbyperson.component.css']
})
export class GetbyPersonComponent implements OnInit {
  person_id: any;
  constructor(private actRoute: ActivatedRoute, private service: AccountService) { }

  AccountList:any=[];
  ModalTitle:string="";
  ActivateAddEditAccountComp:boolean=false;
  account:any;
  searchModel:any;
  ngOnInit(): void {
    this.actRoute.paramMap.subscribe(params => {
      this.person_id = params.get('id');
    });
    this.refreshAccountsList();
  }

  refreshAccountsList(){
    this.service.getAccountByPersonCode(this.person_id).subscribe(data=>{
      console.log(data.returnObject);
      this.AccountList=data.returnObject;
    })
  }

  addAccountClick(){
    this.account={
      code:0,
      personCode:Number(this.person_id),
      accountNumber:"",
      balance:0, 
      active:true
    }
    this.ModalTitle = "Add Account";
    this.ActivateAddEditAccountComp=true;
  }

  editAccountClick(item: any){
    this.account = item;
    this.ModalTitle = "Edit Account";
    this.ActivateAddEditAccountComp=true;
  }

  closeClick() {
    this.ActivateAddEditAccountComp=false;
    this.refreshAccountsList();
  }
  
  deleteAccountClick(code: number){
    if (confirm("Are you sure that you want to delete this record?")){
      this.service.closeAccount(code).subscribe(res=>{
      this.refreshAccountsList();
      alert(res.userInterfaceMessage.toString())
      
      });
    }
  }
}
