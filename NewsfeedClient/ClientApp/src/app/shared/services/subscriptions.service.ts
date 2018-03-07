import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class SubscriptionsService {
  //everything will come from JWT token in request header so logic is a little different
  constructor(private http: HttpClient) { }

  subscribeToDigest(digestId: number, userId: string) {
    return this.http.post('/api/subscriptions/' + userId + '/digests/' + digestId, null);
  }

  unsubscribeFromDigest(digestId: number, userId: string) {
    return this.http.delete('/api/subscriptions/' + userId + '/digests/' + digestId);
  }
}
