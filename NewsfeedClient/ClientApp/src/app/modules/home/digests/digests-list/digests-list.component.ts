import { Component } from '@angular/core';
import { DigestsService } from '../../../../shared/services/digests.service';
import { Digest } from '../../../../shared/models/digest';
import { UsersService } from '../../../../shared/services/users.service';
import { MatDialog, MatSnackBar } from '@angular/material';
import { DigestCreationComponent } from '../digest-creation/digest-creation.component';

@Component({
    selector: 'digests-digests-list',
    templateUrl: './digests-list.component.html',
    styleUrls: ['./digests-list.component.css']
})

export class DigestsListComponent {

  currentUserId: number;
  digests: Digest[];
  newDigestName: string;

  constructor(private digestsService: DigestsService, private usersService: UsersService,
    public dialog: MatDialog, private snackBar: MatSnackBar) { }

  ngOnInit() {
    this.currentUserId = this.getUserId();
    this.getDigests(this.currentUserId);
  }

  getUserId() {
    return localStorage['currentUser'];
  }

  getDigests(userId: number) {
    this.usersService.getDigestsByUser(userId)
      .subscribe((digests: Digest[]) => {
        this.digests = digests;
        console.log('Pushed ' + digests.length + ' digests by user #' + userId);
      });
  }

  createDigest()
  {
    this.newDigestName = '';
    let dialogRef = this.dialog.open(DigestCreationComponent, {
      data: { newDigestName: this.newDigestName }
    });

    dialogRef.afterClosed().subscribe(result => {
      this.newDigestName = result;
      console.log('Value of newDigestName: ' + this.newDigestName);
      if (this.newDigestName.length>0) {
        this.digestsService.createDigest(this.newDigestName, this.currentUserId.toString())
          .subscribe((response: string) => {
            this.snackBar.open(response, 'Okay', {
              duration: 5000,
            });
            this.getDigests(this.currentUserId);
          });
      }
    });

   
  }
}
