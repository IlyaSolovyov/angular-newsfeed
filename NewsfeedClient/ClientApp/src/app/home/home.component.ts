import { Component } from '@angular/core';
import { Post } from '../post';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-home',
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
