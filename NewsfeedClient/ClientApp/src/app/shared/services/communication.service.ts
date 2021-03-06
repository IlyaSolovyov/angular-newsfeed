import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class CommunicationService {

  constructor() { }

  private subscriptionsUpdateNeededSource = new BehaviorSubject<boolean>(false);
  subscriptionsUpdateNeeded = this.subscriptionsUpdateNeededSource.asObservable();

  triggerSubscriptionsUpdate() {
    this.subscriptionsUpdateNeededSource.next(true);
  }

  confirmSubscriptionsUpdate() {
    this.subscriptionsUpdateNeededSource.next(false);
  }

  private sourcesUpdateNeededSource = new BehaviorSubject<boolean>(false);
  sourcesUpdateNeeded = this.sourcesUpdateNeededSource.asObservable();

  triggerSourcesUpdate() {
    this.sourcesUpdateNeededSource.next(true);
  }

  confirmSourcesUpdate() {
    this.sourcesUpdateNeededSource.next(false);
  }
}
