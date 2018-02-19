import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { exportNewsfeedModule } from './newsfeed/newsfeed.module';

import { FoldersComponent } from './folders/folders.component';
import { FriendsComponent } from './friends/friends.component';
import { SettingsComponent } from './settings/settings.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from '../../shared/guards/auth.guard';



const pagesRoutes: Routes = [
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'newsfeed', loadChildren: 'app/modules/home/newsfeed/newsfeed.module#NewsfeedModule'},
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
