import { Component, inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';

@Component({
  selector: 'app-page-w-login',
  imports: [],
  templateUrl: './page-w-login.html',
})
export class PageWLogin {
  private readonly authService = inject(AuthService);

  login() {
    this.authService.loginWithRedirect();
  }
}
