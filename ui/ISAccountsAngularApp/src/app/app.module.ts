import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { JwPaginationModule } from 'jw-angular-pagination';

import { DatePickerModule } from '@syncfusion/ej2-angular-calendars';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonsComponent } from './persons/persons.component';
import { GetallComponent } from './persons/getall/getall.component';
import { AddEditComponent } from './persons/add-edit/add-edit.component';
import { DeleteComponent } from './persons/delete/delete.component';
import { SearchComponent } from './persons/search/search.component';
import { AccountsComponent } from './accounts/accounts.component';
import { GetbyPersonComponent } from './accounts/getbyperson/getbyperson.component';
import { AccountAddEditComponent } from './accounts/acc-add-edit/acc-add-edit.component';
import { TransAddEditComponent } from './transactions/trans-add-edit/trans-add-edit.component';
import { GetbycodeComponent } from './accounts/getbycode/getbycode.component';
import { CloseComponent } from './accounts/close/close.component';
import { TransactionsComponent } from './transactions/transactions.component';
import { GetbyaccountComponent } from './transactions/getbyaccount/getbyaccount.component';

import {PersonService} from './_services/person.service';
import {AccountService} from './_services/account.service';
import {TransactionService} from './_services/transaction.service';

import {HttpClientModule} from '@angular/common/http';
import {FormsModule,ReactiveFormsModule} from '@angular/forms'
import { DatePipe } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';


@NgModule({
  declarations: [
    AppComponent,
    PersonsComponent,
    GetallComponent,
    AddEditComponent,
    DeleteComponent,
    SearchComponent,
    AccountsComponent,
    GetbyPersonComponent,
    GetbycodeComponent,
    AccountAddEditComponent,
    CloseComponent,
    TransactionsComponent,
    TransAddEditComponent,
    GetbyaccountComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent
  ],
  imports: [
    BrowserModule,
    JwPaginationModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    DatePickerModule 
  ],
  providers: [PersonService, AccountService, TransactionService, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
