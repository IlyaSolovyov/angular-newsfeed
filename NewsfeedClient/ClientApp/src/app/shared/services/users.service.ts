import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Digest } from '../models/digest';
import { User } from '../models/user';

@Injectable()
export class UsersService {

  constructor(private http: HttpClient) {}

  getProfileData(userId: number)
  {
    return this.http.get<User>('/api/users/' + userId);
  }

  getDigestsByUser(userId: number) {
    return this.http.get<Digest[]>('/api/users/' + userId + '/digests');
  }

  getSubscriptionsByUser(userId: number) {
    return this.http.get<Digest[]>('/api/users/' + userId + '/subscriptions');
  }

  getFriendsByUser(userId: number) {
    return this.http.get<User[]>('api/users/' + userId + '/friends');
  }

}
