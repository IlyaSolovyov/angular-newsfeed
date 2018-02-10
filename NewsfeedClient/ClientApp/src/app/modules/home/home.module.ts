import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HomeRoutingModule } from './home-routing.module';

import { FoldersComponent } from './folders/folders.component';
import { FriendsComponent } from './friends/friends.component';
import { NewsfeedComponent } from './newsfeed/newsfeed.component';
import { SettingsComponent } from './settings/settings.component';
import { HomeComponent } from './home/home.component';
import { MaterialModule } from '../../shared/material.module';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    HomeRoutingModule
  ],
  declarations: [
    HomeComponent,
    FoldersComponent,
    FriendsComponent,
    NewsfeedComponent,
    SettingsComponent,
    
  ]
})
export class HomeModule {
}
