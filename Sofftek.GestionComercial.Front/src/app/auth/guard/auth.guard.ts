import { AuthServiceService } from '../Service/auth-service.service'; 
import { Injectable } from '@angular/core';
import { CanActivate, CanLoad, Route, UrlSegment, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, CanActivateChild } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild {

  tokenDecode : any;

  constructor(
    private router: Router,

    private authService: AuthServiceService,
  ) { }
  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | UrlTree | Observable<boolean | UrlTree> | Promise<boolean | UrlTree> {
    if (this.authService.isLoggedIn !== true) {
      window.alert("DENEGADO");
      this.router.navigateByUrl('login');
      return false;
    } else {
      
      const permissions = localStorage.getItem('app.ngx-permissions');

      return true;
    }
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): Observable<boolean> | Promise<boolean> | boolean {

    if (this.authService.isLoggedIn !== true) {
      window.alert("DENEGADO");
      this.router.navigateByUrl('login');
      return false;
    } else {
      const permissions = localStorage.getItem('app.ngx-permissions');

      return true;
    }


  }

}
