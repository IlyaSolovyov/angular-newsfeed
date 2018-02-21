import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../shared/material.module';
import { HomeRoutingModule } from './home-routing.module';

import { DigestsComponent } from './digests/digests.component';
import { FriendsComponent } from './friends/friends.component';
import { SettingsComponent } from './settings/settings.component';
import { HomeComponent } from './home/home.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    HomeRoutingModule,
  ],
  declarations: [
    HomeComponent,
    DigestsComponent,
    FriendsComponent,
    SettingsComponent,
    
  ]
})
export class HomeModule {
}
