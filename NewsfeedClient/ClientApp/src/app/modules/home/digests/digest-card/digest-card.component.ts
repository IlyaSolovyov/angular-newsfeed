import { Component, Input } from '@angular/core';
import { Digest } from '../../../../shared/models/digest';
import { UsersService } from '../../../../shared/services/users.service';
import { SubscriptionsService } from '../../../../shared/services/subscriptions.service';
import { MatSnackBar, MatDialog } from '@angular/material';
import { CommunicationService } from '../../../../shared/services/communication.service';
import { Source } from '../../../../shared/models/source';
import { SourceListEditComponent } from '../source-list-edit/source-list-edit.component';
import { DigestsService } from '../../../../shared/services/digests.service';


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
      private snackBar: MatSnackBar, private communicationService: CommunicationService,
      private dialog: MatDialog, private digestsService: DigestsService) { }

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

    openEditSourcesDialog(digestId: number)
    {
      let source: Source;
      let dialogRef = this.dialog.open(SourceListEditComponent, {
        data: { digestId: digestId }
      });

      dialogRef.afterClosed().subscribe(() => {
        this.digestsService.getDigestData(digestId).subscribe(updatedDigestData => {
          this.digest = updatedDigestData;
        }

      });
    }
}
