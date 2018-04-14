import { Component, Input } from '@angular/core';
import { Digest } from '../../../../shared/models/digest';
import { MatDialog, MatSnackBar } from '@angular/material';
import { CommunicationService } from '../../../../shared/services/communication.service';
import { SubscriptionsService } from '../../../../shared/services/subscriptions.service';

@Component({
    selector: 'digests-subscription-card',
    templateUrl: './subscription-card.component.html',
    styleUrls: ['./subscription-card.component.css']
})

export class SubscriptionCardComponent {
    @Input() public subscription: Digest;
    currentUserId: number;

    constructor(private subscriptionsService: SubscriptionsService,
      private snackBar: MatSnackBar, private communicationService: CommunicationService,
      private dialog: MatDialog) { }

    ngOnInit() {
      this.currentUserId = this.getUserId();
    }

    getUserId() {
      return localStorage['currentUser'];
    }

    unsubscribe(userId: number) {
      this.subscriptionsService.unsubscribeFromDigest(this.subscription.id, this.currentUserId.toString())
        .subscribe((response: string) => {

          this.snackBar.open(response, 'Okay', {
            duration: 5000,
          });

          this.communicationService.triggerSubscriptionsUpdate();
        });
    }
}
