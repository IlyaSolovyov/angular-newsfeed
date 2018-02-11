import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NewsfeedModule } from './newsfeed/newsfeed.module';

import { FoldersComponent } from './folders/folders.component';
import { FriendsComponent } from './friends/friends.component';
import { SettingsComponent } from './settings/settings.component';
import { HomeComponent } from './home/home.component';


const pagesRoutes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    children: [
      { path: 'newsfeed', loadChildren: () => NewsfeedModule },
      { path: 'folders', component: FoldersComponent },
      { path: 'friends', component: FriendsComponent },
      { path: 'settings', component: SettingsComponent },
      { path: '', redirectTo: 'newsfeed', pathMatch: 'full' },
    ]
  }
  
];

@NgModule({
  imports: [
    RouterModule.forChild(pagesRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class HomeRoutingModule {
}
