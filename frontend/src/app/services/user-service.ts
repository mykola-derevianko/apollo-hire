import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment.development';
@Injectable({
  providedIn: 'root',
})
export class UserService {
  private readonly httpClient = inject(HttpClient);
  private readonly apiUrl = environment.api_url;


  syncUser(){
    return this.httpClient.post(`${this.apiUrl}/api/user/sync`, {});
  }

}
