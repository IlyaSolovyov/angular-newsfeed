import { Component } from '@angular/core';
import { DigestsService } from '../../../../shared/services/digests.service';
import { Digest } from '../../../../shared/models/digest';
import { UsersService } from '../../../../shared/services/users.service';

@Component({
    selector: 'digests-digests-list',
    templateUrl: './digests-list.component.html',
    styleUrls: ['./digests-list.component.css']
})

export class DigestsListComponent {

  currentUserId: number;
  digests: Digest[];

  constructor(private digestsService: DigestsService, private usersService:UsersService) { }

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
        console.log("Pushed " + digests.length + " digests by user #" + userId);
      });
  }
}
