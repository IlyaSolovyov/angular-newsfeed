import { Component } from '@angular/core';
import { UsersService } from '../../../../shared/services/users.service';
import { Digest } from '../../../../shared/models/digest';
import { User } from '../../../../shared/models/user';

@Component({
  templateUrl: './newsfeed.component.html',
  styleUrls: ['./newsfeed.component.css']
})

export class NewsfeedComponent {
  currentUser: User;
  digests: Digest[];

  constructor(private usersService: UsersService) { }

  ngOnInit() {
    this.getCurrentUser();
    this.getDigests(this.currentUser.id);
  }

  getCurrentUser() {
    this.currentUser = this.usersService.getCurrentUser();
  }

  getDigests(userId: number) {
    this.usersService.getDigestsByUser(userId)
      .subscribe((digests: Digest[]) => {
        this.digests = digests;
        console.log("Digest count: " + this.digests.length);
      });
  }
}

