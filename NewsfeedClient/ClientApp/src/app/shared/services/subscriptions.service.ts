import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class SubscriptionsService {

  constructor(private http: HttpClient) { }

  subscribeToDigest(digestId: number, userId: string) {
    this.http.post('/api/subscriptions/' + digestId, userId);
  }

  unsubscribeFromDigest(digestId: number, userId: string) {
    this.http.delete('/api/subscriptions/' + digestId, userId);
  }
}
