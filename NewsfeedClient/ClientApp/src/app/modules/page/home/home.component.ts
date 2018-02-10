import { Component } from '@angular/core';
import { Post } from '../../../shared/models/post';
import { PostsService } from '../../../shared/services/posts.service';



@Component({
  selector: 'page-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  posts: Post[];
  postJsons: string[];
  post: string = "Didn't fetch yet.";
  constructor(public postsService: PostsService) {
  }

  ngOnInit() {
    this.fetchNews();
  }

  fetchNews() {
    console.log("Starting news download.");
    this.postsService.getPosts()
      .subscribe((posts: Post[]) => {
        this.posts = posts;
      });
  }
}
