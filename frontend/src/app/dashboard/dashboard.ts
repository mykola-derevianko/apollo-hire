import { Component, inject } from '@angular/core';
import { AuthService } from '@auth0/auth0-angular';
import { UserService } from '../services/user-service';
import { environment } from '../../environments/environment';
import {HttpClient} from '@angular/common/http';
@Component({
  selector: 'app-dashboard',
  imports: [],
  templateUrl: './dashboard.html',
})
export class Dashboard {
  private readonly authService = inject(AuthService);
  private readonly userService = inject(UserService);
  private readonly httpClient = inject(HttpClient);
  private readonly apiUrl = environment.api_url;

  ngOnInit() {
    this.userService.syncUser().subscribe({
       next: () => {
        this.httpClient.get(`${this.apiUrl}/api/application`).subscribe({
          next: (applications) => {
            console.log('Applications retrieved:', applications);
          },
          error: (error) => {
            console.error('Error retrieving applications', error);
          }
        });
      }
    });
  }



  logout() {
    this.authService.logout({ logoutParams: { returnTo: window.location.origin } });
  }
}
