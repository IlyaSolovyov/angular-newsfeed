import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UsersService {

  constructor(private http: HttpClient) { }

  getDigestsByUser(userId: number) {
    return this.http.get('/api/users/' + userId + '/digests');
  }

  getFriedsByUser(userId: number) {
    return this.http.get('api/users/' + userId + '/friends');
  }

}
