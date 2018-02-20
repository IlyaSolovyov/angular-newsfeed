import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'account-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent {

  constructor(private router: Router) { }

  username: string;
  email: string;
  password: string;

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  usernameFormControl = new FormControl('', [Validators.required]);
  passFormControl = new FormControl('', [Validators.required]);
  hide = true;

  getEmailErrorMessage() {
    return this.emailFormControl.hasError('required') ? 'This field is required' :
      this.emailFormControl.hasError('email') ? 'Not a valid email' :
        '';
  }

  getUsernameErrorMessage() {
    return this.usernameFormControl.hasError('required') ? 'This field is required' :
      '';
  }

  getPassErrorMessage() {
    return this.passFormControl.hasError('required') ? 'This field is required' :
      '';
  }

  register() {
    this.router.navigate(['account/login']);
  }
}
