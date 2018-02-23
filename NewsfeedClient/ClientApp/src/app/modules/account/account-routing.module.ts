import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AnonymousGuard } from '../../shared/guards/anonymous.guard';
import { AuthGuard } from '../../shared/guards/auth.guard';

import { AccountComponent } from './account/account.component';
import { LoginComponent } from './login/login/login.component';
import { RegisterComponent } from './register/register.component';
import { LogoutComponent } from './logout/logout.component';


const accountRoutes: Routes = [
  {
    path: 'account',
    component: AccountComponent,
    children: [
      { path: 'login', component: LoginComponent, canActivate: [AnonymousGuard], },
      { path: 'logout', component: LogoutComponent, canActivate: [AuthGuard],},
      { path: 'register', component: RegisterComponent, canActivate: [AnonymousGuard], },
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
