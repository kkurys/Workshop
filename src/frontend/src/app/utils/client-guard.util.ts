import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { RolesUtil } from './roles.util';
import { AuthService } from '../services/auth.service';

@Injectable()
export class ClientGuard implements CanActivate {

    constructor(
        private router: Router, 
        private roles: RolesUtil,
        private authService: AuthService) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.authService.isLoggedIn() && this.roles.isInRole("Client")) {
            return true;
        }

        localStorage.clear();
        this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}
