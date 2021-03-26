import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import {SearchModel} from 'src/app/core/Models/core.models';
@Component({
  selector: 'app-search-person',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})


export class SearchComponent implements OnInit {
@Output() searchEvent = new EventEmitter<SearchModel>();

searchModel={} as SearchModel;
  constructor() { }

  ngOnInit(): void {
  }
  
searchPeople(value: SearchModel) {
  console.log(value);
  this.searchEvent.emit(value)
}
}
