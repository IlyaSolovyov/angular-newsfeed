import { Component, Input } from '@angular/core';
import { PostsService } from '../../../../shared/services/posts.service';
import { Digest } from '../../../../shared/models/digest';
import { Post } from '../../../../shared/models/post';

@Component({
    selector: 'newsfeed-feed',
    templateUrl: './feed.component.html',
    styleUrls: ['./feed.component.css']
})

export class FeedComponent {
  @Input() public digest: Digest;
  posts: Post[];

  constructor(private postsService: PostsService) { }

  ngOnInit() {
    this.getPosts(this.digest.id);
  }

  getPosts(digestId: number) {
    this.postsService.getPostsByDigest(digestId)
      .subscribe((posts: Post[]) => {
        this.posts = posts;
        console.log("Post count in " + this.digest.name + " digest: " + this.posts.length);
      });
  }

}
