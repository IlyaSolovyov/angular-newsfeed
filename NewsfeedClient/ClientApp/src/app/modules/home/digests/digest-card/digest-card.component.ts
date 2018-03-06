import { Component, Input } from '@angular/core';
import { Digest } from '../../../../shared/models/digest';
import { UsersService } from '../../../../shared/services/users.service';
import { SubscriptionsService } from '../../../../shared/services/subscriptions.service';
import { MatSnackBar } from '@angular/material';
import { CommunicationService } from '../../../../shared/services/communication.service';


@Component({
    selector: 'digests-digest-card',
    templateUrl: './digest-card.component.html',
    styleUrls: ['./digest-card.component.css']
})

export class DigestCardComponent {
 
    @Input() public digest: Digest;
    public subscribed: boolean;
    currentUserId: number;
    constructor(private usersService: UsersService, private subscriptionsService: SubscriptionsService,
      private snackBar: MatSnackBar, private communicationService: CommunicationService,) { }

    ngOnInit() {
      this.currentUserId = this.getUserId();
      this.checkForSubscription(this.currentUserId)
    }

    getUserId() {
      return localStorage['currentUser'];
    }

    checkForSubscription(userId: number) {

      this.usersService.getSubscriptionsByUser(this.currentUserId)
        .subscribe((subscriptions: Digest[]) => {
          this.subscribed= (subscriptions.findIndex((digest) => digest.id == this.digest.id)) != (-1);
        });
    }

    subscribe(userId: number) {
      console.log(userId);
      this.subscriptionsService.subscribeToDigest(this.digest.id, this.currentUserId.toString())
        .subscribe((response: string) => {

        this.snackBar.open(response, 'Okay', {
          duration: 5000,
        });

        this.communicationService.triggerSubscriptionsUpdate();
        this.checkForSubscription(userId);
      });;
    }

    unsubscribe(userId: number) {
      this.subscriptionsService.unsubscribeFromDigest(this.digest.id, this.currentUserId.toString())
        .subscribe((response: string) => {

          this.snackBar.open(response, 'Okay', {
            duration: 5000,
          });

          this.communicationService.triggerSubscriptionsUpdate();
          this.checkForSubscription(userId);
        });;
    }

}
