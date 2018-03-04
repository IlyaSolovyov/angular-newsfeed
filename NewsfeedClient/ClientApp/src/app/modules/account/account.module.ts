import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AccountRoutingModule } from './account-routing.module';
import { MaterialModule } from '../../shared/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AccountService } from '../../shared/services/account.service';

import { AccountComponent } from './account/account.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { LogoutComponent } from './logout/logout.component';


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
    RegisterComponent,
    LogoutComponent
  ],
  providers: [
    AccountService
  ]
})
export class AccountModule {
}
