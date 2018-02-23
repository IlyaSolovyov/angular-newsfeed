import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../../shared/material.module';
import { NewsfeedRoutingModule } from './newsfeed-routing.module';

import { NewsfeedComponent } from './newsfeed/newsfeed.component';
import { FeedComponent } from './feed/feed.component';
import { PostComponent } from './post/post.component';
import { PostListComponent } from './post-list/post-list.component';
import { PostDetailedComponent } from './post-detailed/post-detailed.component';

import { UsersService } from '../../../shared/services/users.service';
import { PostsService } from '../../../shared/services/posts.service';


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
    PostListComponent,
    PostDetailedComponent
  ],
  providers: [
    UsersService,
    PostsService
  ]
})
export class NewsfeedModule {
}

export function exportNewsfeedModule() {
  return NewsfeedModule;
}
