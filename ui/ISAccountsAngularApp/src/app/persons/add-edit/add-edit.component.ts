import { Component, OnInit, Input } from '@angular/core';
import {SharedService} from 'src/app/shared.service';
import { from } from 'rxjs';

@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {

  constructor(private service: SharedService) { }

  @Input() person:any;
  Code:number=0;
  Name:string="";
  Surname:string="";
  IdNumber:string="";
  Active:boolean=true;
  ngOnInit(): void {
    this.Code = this.person.code;
    this.Name = this.person.name;
    this.Surname = this.person.surname;
    this.IdNumber = this.person.idNumber;
    this.Active = this.person.active;
  }

  addPerson(){
  var val = {
            Code: this.Code,
            Name: this.Name,
            Surname: this.Surname,
            IdNumber:this.IdNumber,
            Active:true 
          }
  this.service.addPerson(val).subscribe(res=>{
    alert(res.userInterfaceMessage.toString())
  });
        
  }

  updatePerson(){
    var val = {
      Code: this.Code,
      Name: this.Name,
      Surname: this.Surname,
      IdNumber:this.IdNumber,
      Active:this.Active 
    }
this.service.updatePerson(val).subscribe(res=>{
alert(res.userInterfaceMessage.toString())
});
 
  }
}
