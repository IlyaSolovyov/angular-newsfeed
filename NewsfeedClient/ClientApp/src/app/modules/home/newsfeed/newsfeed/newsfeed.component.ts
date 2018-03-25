import { Component } from '@angular/core';
import { UsersService } from '../../../../shared/services/users.service';
import { Digest } from '../../../../shared/models/digest';
import { User } from '../../../../shared/models/user';

@Component({
  templateUrl: './newsfeed.component.html',
  styleUrls: ['./newsfeed.component.css']
})

export class NewsfeedComponent {

  currentUserId: number;
  digests: Digest[];

  constructor(private usersService: UsersService) {}

  ngOnInit() {
    this.currentUserId = this.getUserId();
    this.getDigests(this.currentUserId);
  }

  getUserId() {
    return localStorage['currentUser'];
  }

  getDigests(userId: number) {
    this.usersService.getSubscriptionsByUser(userId)
      .subscribe((digests: Digest[]) => {
        this.digests = digests;
        console.log('Pushed ' + digests.length + ' digests by user #' + userId);
      });
  }
}

