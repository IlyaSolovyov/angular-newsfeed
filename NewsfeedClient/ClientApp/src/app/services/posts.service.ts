import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PageService {

  constructor(private http: HttpClient) { }

    getPosts() {
        return this.http.get('/api/news/');      
    }

    getPost(id: number) {
      return this.http.get('api/news/' + id);
    }
}
