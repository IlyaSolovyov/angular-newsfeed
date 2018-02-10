import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule } from './account-routing.module';

import { AccountComponent } from './account/account.component';
import { LoginComponent } from './login/login/login.component';


@NgModule({
  imports: [
    CommonModule,
    AccountRoutingModule
  ],
  declarations: [
    AccountComponent,
    LoginComponent
  ]
})
export class AccountModule {
}
