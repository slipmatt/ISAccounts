import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import {PersonsComponent} from './persons/persons.component';
import {AccountsComponent} from './accounts/accounts.component';
import {GetbyPersonComponent} from './accounts/getbyperson/getbyperson.component';
import {TransactionsComponent} from './transactions/transactions.component';
import { GetbyaccountComponent } from './transactions/getbyaccount/getbyaccount.component';

import {HomeComponent} from './home/home.component';
import {AboutComponent} from './about/about.component';
import {ContactComponent} from './contact/contact.component';

const routes: Routes = [
  {path:'Person',component:PersonsComponent},
  {path:'Accounts/',component:AccountsComponent},
  {path:'Accounts/GetByPerson/:id',component:GetbyPersonComponent},
  {path:'Transactions/:id',component:TransactionsComponent},
  {path:'Transactions/GetByAccount/:id',component:GetbyaccountComponent},

  {path:'Home',component:HomeComponent},
  {path:'About',component:AboutComponent},
  {path:'Contact',component:ContactComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
