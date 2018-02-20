import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';
import { AccountService } from '../../../../shared/services/account.service';

@Component({
    selector: 'account-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent {

  constructor(private router: Router, private accountService: AccountService, private snackBar: MatSnackBar) { }

  email: string;
  password: string;

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  passFormControl = new FormControl('', [Validators.required]);
  hide = true;

  getEmailErrorMessage() {
    return this.emailFormControl.hasError('required') ? 'You must enter a value' :
      this.emailFormControl.hasError('email') ? 'Not a valid email' :
            '';
  }

  getPassErrorMessage() {
    return this.passFormControl.hasError('required') ? 'This field is required' :
      '';
  }

  login(email, password) {
    this.accountService.login(email, password)
      .subscribe((response: string) => {
        localStorage.setItem('currentUser', JSON.stringify(response));
        this.snackBar.open('Successfully signed in as ' + localStorage.getItem("currentUser").toString(), 'Okay', {
          duration: 2000,
        });
      });
    this.router.navigate(['/home']);
  }

}
