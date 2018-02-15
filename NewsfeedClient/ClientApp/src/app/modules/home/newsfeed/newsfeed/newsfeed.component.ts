import { Component } from '@angular/core';
import { UsersService } from '../../../../shared/services/users.service';
import { Digest } from '../../../../shared/models/digest';
import { User } from '../../../../shared/models/user';

@Component({
  templateUrl: './newsfeed.component.html',
  styleUrls: ['./newsfeed.component.css']
})

export class NewsfeedComponent {

  constructor(private usersService: UsersService) { }

  currentUser: User;
  digests: Digest[];

  ngOnInit() {
    this.getCurrentUser();
    this.getDigests(this.currentUser.id);
    console.log(this.digests)
  }

  getCurrentUser() {
    this.currentUser = this.usersService.getCurrentUser();
  }

  getDigests(userId: number) {
    this.usersService.getDigestsByUser(this.currentUser.id)
      .subscribe((digests: Digest[]) => {
        this.digests = digests;
        console.log("Digest count: " + this.digests.length);
      });
  }
}

