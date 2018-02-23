import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../shared/material.module';
import { HomeRoutingModule } from './home-routing.module';

import { FriendsComponent } from './friends/friends.component';
import { SettingsComponent } from './settings/settings.component';
import { HomeComponent } from './home/home.component';
import { SidenavProfileComponent } from './home/sidenav-profile/sidenav-profile.component';
import { AccountService } from '../../shared/services/account.service';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    HomeRoutingModule,
  ],
  declarations: [
    HomeComponent,
    FriendsComponent,
    SettingsComponent,
    SidenavProfileComponent
  ],
  providers: [
    AccountService
  ]
})
export class HomeModule {
}
