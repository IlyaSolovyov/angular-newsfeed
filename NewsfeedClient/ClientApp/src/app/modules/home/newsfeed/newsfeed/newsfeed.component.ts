import { Component } from '@angular/core';
import { UsersService } from '../../../../shared/services/users.service';
import { Digest } from '../../../../shared/models/digest';
import { User } from '../../../../shared/models/user';

@Component({
  templateUrl: './newsfeed.component.html',
  styleUrls: ['./newsfeed.component.css']
})

export class NewsfeedComponent {
  currentUser: User = null;

  constructor(private usersService: UsersService) {}

  ngOnInit() {
    let userId = +localStorage.getItem('currentUser');
    this.getCurrentUser(userId);
  }

  getCurrentUser(userId: number) {
    this.usersService.getProfileData(userId)
      .subscribe((user: User) => {
        this.currentUser = user;
      });
    this.usersService.getDigestsByUser(userId)
      .subscribe((digests: Digest[]) => {
        this.currentUser.digests = digests;
      });
  }
}

