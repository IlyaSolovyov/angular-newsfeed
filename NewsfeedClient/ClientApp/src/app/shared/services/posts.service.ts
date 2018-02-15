import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PostsService {

  constructor(private http: HttpClient) { }

    getPostsByDigest(digestId: number) {
        return this.http.get('/api/posts/digests/' + digestId);      
    }

    getPostsByUser(userId: number) {
        return this.http.get('api/posts/users/' + userId);
    }
}
