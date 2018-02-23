import { Component } from '@angular/core';
import { User } from '../../../../shared/models/user';
import { AccountService } from '../../../../shared/services/account.service';

@Component({
    selector: 'home-sidenav-profile',
    templateUrl: './sidenav-profile.component.html',
    styleUrls: ['./sidenav-profile.component.css']
})

export class SidenavProfileComponent {
    user: User;
    avatarPath: string;
    constructor(private accountService: AccountService) {}

     ngOnInit() {
      this.getCurrentUserData(+localStorage.getItem('currentUser'));
    }

    getCurrentUserData(userId: number) {
      this.accountService.getAccountData(userId)
        .subscribe((user: User) => {
          this.user = user;
          this.avatarPath = 'Images//' + user.avatarFilename;
        });
    }
}
