import { Component, OnInit, Input } from '@angular/core';
import {PersonService} from 'src/app/_services/person.service';
import { from } from 'rxjs';


@Component({
  selector: 'app-add-edit',
  templateUrl: './add-edit.component.html',
  styleUrls: ['./add-edit.component.css']
})
export class AddEditComponent implements OnInit {

  constructor(private service: PersonService) { }

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
      code: this.Code,
      name: this.Name,
      surname: this.Surname,
      idNumber:this.IdNumber,
      active:true 
    }
    this.service.addPerson(val).subscribe(res=>{
      alert(res.userInterfaceMessage.toString())
    });
          
    }

    updatePerson(){
      var val = {
        code: this.Code,
        name: this.Name,
        surname: this.Surname,
        idNumber:this.IdNumber,
        active:this.Active 
      }
      this.service.updatePerson(val).subscribe(res=>{
      alert(res.userInterfaceMessage.toString())
    });
 
  }
}
