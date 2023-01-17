import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import jwtDecode from 'jwt-decode';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor{
  tokenDecode: any;
  constructor(private router: Router) { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token = localStorage.getItem("_TK");
  if(token!=null)
  {
    this.tokenDecode = jwtDecode(token!);
    const expira = new Date(0);
    const now = new Date();
    expira.setUTCSeconds(this.tokenDecode.exp);
    if(now>expira)
    {
      this.router.navigateByUrl('login');
      console.log('Se agotó el tiempo de la sesión');
    }
  }
    
    let jwtoken = req.clone({
      setHeaders:{
        Authorization: `Bearer ${token}`
      }
    })

    return next.handle(jwtoken);

  }
}
