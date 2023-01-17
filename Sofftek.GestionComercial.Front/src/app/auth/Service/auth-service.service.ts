import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  private env = environment;
  protected endpoint: string;

  constructor(
    private http: HttpClient,
    private router: Router
  ) {
    this.endpoint = `${environment.AUTH}`;
  }

  postLogin(auth: any){
    return this.http.post(`${this.endpoint}/Auth/Auth`, auth);
  }

  get isLoggedIn(): boolean {
    const user = localStorage.getItem('_TK');
    return user !== 'null' ? true : false;
  }

  logout(): void{
    localStorage.clear();
    this.router.navigate(['/']);
  }
}
