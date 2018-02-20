import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule } from './account-routing.module';
import { MaterialModule } from '../../shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AccountService } from '../../shared/services/account.service';

import { AccountComponent } from './account/account.component';
import { LoginComponent } from './login/login/login.component';
import { RegisterComponent } from './register/register.component';


@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    AccountRoutingModule,
  ],
  declarations: [
    AccountComponent,
    LoginComponent,
    RegisterComponent
  ],
  providers: [
    AccountService
  ]
})
export class AccountModule {
}
