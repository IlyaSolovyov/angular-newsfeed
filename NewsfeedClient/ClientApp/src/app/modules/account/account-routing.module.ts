import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AccountComponent } from './account/account.component';
import { LoginComponent } from './login/login/login.component';


const accountRoutes: Routes = [
  {
    path: 'account',
    component: AccountComponent,
    children: [
      {path: 'login', component: LoginComponent},
      { path: '', redirectTo: 'login', pathMatch: 'full'}
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(accountRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AccountRoutingModule {
}
