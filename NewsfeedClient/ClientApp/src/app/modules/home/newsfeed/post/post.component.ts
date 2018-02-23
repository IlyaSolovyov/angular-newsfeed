import { Component, Input } from '@angular/core';
import { Post } from '../../../../shared/models/post';

@Component({
    selector: 'newsfeed-post',
    templateUrl: './post.component.html',
    styleUrls: ['./post.component.css']
})

export class PostComponent {
  @Input() public post: Post;
}
