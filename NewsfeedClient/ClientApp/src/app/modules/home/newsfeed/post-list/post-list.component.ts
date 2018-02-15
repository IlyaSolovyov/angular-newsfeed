import { Component, Input } from '@angular/core';
import { Post } from '../../../../shared/models/post';

@Component({
    selector: 'newsfeed-post-list',
    templateUrl: './post-list.component.html',
    styleUrls: ['./post-list.component.css']
})

export class PostListComponent {
  @Input() public posts: Post[];

}
