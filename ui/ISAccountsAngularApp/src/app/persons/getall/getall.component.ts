import { Component, OnInit } from '@angular/core';
import { SharedService} from 'src/app/shared.service'

@Component({
  selector: 'app-getall',
  templateUrl: './getall.component.html',
  styleUrls: ['./getall.component.css']
})
export class GetallComponent implements OnInit {

  constructor(private service: SharedService) { }

  PersonList:any=[];
  ModalTitle:string="";
  ActivateAddEditPersonComp:boolean=false;
  person:any;
  searchModel:any;
  ngOnInit(): void {
    this.refreshPersonsList();
  }

  refreshPersonsList(){
    this.service.getPersonsList().subscribe(data=>{
      this.PersonList=data.returnObject;
    })
  }

  searchPersonsList(item:any){
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
  
  deletePersonClick(code: number){
    if (confirm("Are you sure that you want to delete this record?")){
      this.service.deletePerson(code).subscribe(res=>{
      this.refreshPersonsList();
      alert(res.userInterfaceMessage.toString())
      
      });
    }
  }
}
