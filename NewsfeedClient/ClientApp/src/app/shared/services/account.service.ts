import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class AccountService {

  constructor(private http: HttpClient) { }

  login(email: string, password: string) {
    const formData = new FormData();
    formData.append('email', email);
    formData.append('password', password);

    const headers = new HttpHeaders({ 'enctype': 'multipart/form-data' });

    return this.http.post('/api/account/login', formData, { headers: headers });
  }

  register(username: string, email: string, password: string) {
    const formData = new FormData();
    formData.append('username', username);
    formData.append('email', email);
    formData.append('password', password);

    const headers = new HttpHeaders({ 'enctype': 'multipart/form-data' });

    return this.http.post('/api/account/register', formData, { headers: headers });
  }

  logout(){
    localStorage.clear();
  }

  getAccountData(userId: number) {
    return this.http.get('/api/account/' + userId);
  }

}
