import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { NewsfeedComponent } from './newsfeed/newsfeed.component';


const newsfeedRoutes: Routes = [
  {
    path: '', component: NewsfeedComponent,
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(newsfeedRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class NewsfeedRoutingModule {
}
