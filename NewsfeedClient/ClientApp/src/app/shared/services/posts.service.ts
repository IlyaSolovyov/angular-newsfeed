import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Post } from '../models/post';

@Injectable()
export class PostsService {

  constructor(private http: HttpClient) { }

    getPostsByDigest(digestId: number) {
      return this.http.get<Post[]>('/api/posts/digests/' + digestId);
    }

    getPostsByUser(userId: number) {
      return this.http.get<Post[]>('api/posts/users/' + userId);
    }
}
