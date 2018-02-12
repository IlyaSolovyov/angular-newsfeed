import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../../shared/material.module';
import { NewsfeedRoutingModule } from './newsfeed-routing.module';

import { NewsfeedComponent } from './newsfeed/newsfeed.component';
import { FeedComponent } from './feed/feed.component';
import { PostComponent } from './post/post.component';
import { PostListComponent } from './post-list/post-list.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    NewsfeedRoutingModule
  ],
  declarations: [
    NewsfeedComponent,
    FeedComponent,
    PostComponent,
    PostListComponent
  ]
})
export class NewsfeedModule {
}
