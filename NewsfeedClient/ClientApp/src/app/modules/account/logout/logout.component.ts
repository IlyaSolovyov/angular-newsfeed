import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../../../shared/services/account.service';

@Component({
    selector: 'account-logout',
    templateUrl: './logout.component.html',
    styleUrls: ['./logout.component.css']
})

export class LogoutComponent {

  constructor(private router: Router, private accountService: AccountService) {}

  ngOnInit() {
    this.accountService.logout();
    setTimeout(() => {
      this.router.navigate(['account/login']);
    }, 3000);
    }
}
