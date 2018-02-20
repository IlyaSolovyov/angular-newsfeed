import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
    selector: 'account-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})

export class LoginComponent {

  constructor(private router: Router) { }

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

  login() {
    this.router.navigate(['/home']);
  }

}
