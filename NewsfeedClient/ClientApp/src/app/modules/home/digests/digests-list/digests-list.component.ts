import { Component } from '@angular/core';
import { DigestsService } from '../../../../shared/services/digests.service';
import { Digest } from '../../../../shared/models/digest';
import { UsersService } from '../../../../shared/services/users.service';
import { MatDialog, MatSnackBar } from '@angular/material';
import { DigestCreationComponent } from '../digest-creation/digest-creation.component';
import { CommunicationService } from '../../../../shared/services/communication.service';

@Component({
    selector: 'digests-digests-list',
    templateUrl: './digests-list.component.html',
    styleUrls: ['./digests-list.component.css']
})

export class DigestsListComponent {

  currentUserId: number;
  digests: Digest[];
  subscriptions: Digest[];
  newDigestName: string;

  constructor(private digestsService: DigestsService, private usersService: UsersService,
    private communicationService: CommunicationService,
    private dialog: MatDialog, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.currentUserId = this.getUserId();
    this.fetchData(this.currentUserId); 
  }

  getUserId() {
    return localStorage['currentUser'];
  }

  fetchData(userId: number){
    this.usersService.getSubscriptionsByUser(userId)
      .subscribe((subscriptions: Digest[]) => {
        this.subscriptions = subscriptions;
        this.getDigests(userId);
      });
  }

  getDigests(userId: number) {
    this.usersService.getDigestsByUser(userId)
      .subscribe((digests: Digest[]) => {
        this.digests = digests;
        console.log('Pushed ' + digests.length + ' digests by user #' + userId);
      });
  }


  isUserSubscribed(digest: Digest) {
    return this.subscriptions.includes(digest);
  }

  createDigest(){
    this.newDigestName = '';

    let dialogRef = this.dialog.open(DigestCreationComponent, {
      data: { newDigestName: this.newDigestName }
    });

    dialogRef.afterClosed().subscribe(result => {

      this.newDigestName = result;
      if (this.newDigestName.length > 0) {

        this.digestsService.createDigest(this.newDigestName, this.currentUserId.toString())
          .subscribe((response: string) => {

            this.snackBar.open(response, 'Okay', {
              duration: 5000,
            });

            this.communicationService.triggerSubscriptionsUpdate();
            this.getDigests(this.currentUserId);

          });

      }
    });

   
  }
}
