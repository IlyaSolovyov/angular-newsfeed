import { Component } from '@angular/core';
import { Digest } from '../../../../shared/models/digest';
import { DigestsService } from '../../../../shared/services/digests.service';
import { UsersService } from '../../../../shared/services/users.service';

@Component({
    selector: 'digests-subscriptions-list',
    templateUrl: './subscriptions-list.component.html',
    styleUrls: ['./subscriptions-list.component.css']
})

export class SubscriptionsListComponent {

  currentUserId: number;
  subscriptions: Digest[];

  constructor(private subscriptionsService: DigestsService, private usersService: UsersService) { }

  ngOnInit() {
    this.currentUserId = this.getUserId();
    this.getSubscriptions(this.currentUserId);
  }

  getUserId() {
    return localStorage['currentUser'];
  }

  getSubscriptions(userId: number) {
    this.usersService.getSubscriptionsByUser(userId)
      .subscribe((subscriptions: Digest[]) => {
        this.subscriptions = subscriptions;
        console.log("Pushed " + subscriptions.length + " subscriptions by user #" + userId);
      });
  }
}
