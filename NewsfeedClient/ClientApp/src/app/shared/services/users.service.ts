import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Digest } from '../models/digest';
import { User } from '../models/user';

@Injectable()
export class UsersService {

  currentUser: User;

  constructor(private http: HttpClient) {
    this.currentUser = new User("testUser", null, null, 1);
  }

  getCurrentUser(): User {
    return this.currentUser;
  }

  getDigestsByUser(userId: number) {
    return this.http.get<Digest[]>('/api/users/' + userId + '/digests');
  }

  getFriendsByUser(userId: number) {
    return this.http.get<User[]>('api/users/' + userId + '/friends');
  }

}
