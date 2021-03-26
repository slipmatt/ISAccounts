import { Component, OnInit } from '@angular/core';
import { PersonService} from 'src/app/_services/person.service'
import {SearchModel} from 'src/app/core/Models/core.models';
import {PersonModel} from 'src/app/core/Models/core.models';
@Component({
  selector: 'app-getall',
  templateUrl: './getall.component.html',
  styleUrls: ['./getall.component.css']
})
export class GetallComponent implements OnInit {

  constructor(private service: PersonService) { }

  PersonList:Array<PersonModel>=[];
  PageOfPersonList: Array<PersonModel>=[];
  ModalTitle:string="";
  ActivateAddEditPersonComp:boolean=false;
  ActivateSearchPersonComp:boolean=false;
  person:any;
  searchModel={} as SearchModel;
  ngOnInit(): void {
    this.refreshPersonsList();
  }

  refreshPersonsList(){
    this.service.getPersonsList().subscribe(data=>{
      this.PersonList=data.returnObject;
    })
  }

  onChangePage(pageOfItems: Array<any>) {
    // update current page of items
    this.PageOfPersonList = pageOfItems;
}

  searchPersonClick(){
    this.ActivateSearchPersonComp=true;
  }

  searchPersonsList(item:any){
    console.log(item);
    this.searchModel={
      idNumber:item.idNumber,
      surname:item.surname,
      accountNumber:item.accountNumber
    }
    this.service.searchPerson(this.searchModel).subscribe(data=>{
      this.PersonList=data.returnObject;
    })
  }

  addPersonClick(){
    this.person={
      code:0,
      name:"",
      surname:"",
      idNumber:"", 
      active:true
    }
    this.ModalTitle = "Add Person";
    this.ActivateAddEditPersonComp=true;
  }

  editPersonClick(item: any){
    this.person = item;
    this.ModalTitle = "Edit Person";
    this.ActivateAddEditPersonComp=true;
  }

  closeClick() {
    this.ActivateAddEditPersonComp=false;
    this.refreshPersonsList();
  }

  closeSearchClick() {
    this.ActivateSearchPersonComp=false;
  }
  
  deletePersonClick(code: number){
    if (confirm("Are you sure that you want to delete this record?")){
      this.service.deletePerson(code).subscribe(res=>{
      this.refreshPersonsList();
      alert(res.userInterfaceMessage.toString())
      this.closeClick();
      });
    }
  }
}
