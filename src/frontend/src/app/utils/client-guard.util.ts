import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { RolesUtil } from './roles.util';

@Injectable()
export class ClientGuard implements CanActivate {

    constructor(private router: Router, private roles: RolesUtil) { }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (this.roles.isInRole("Client")) {
            return true;
        }

        localStorage.clear();
        this.router.navigate(['login'], { queryParams: { returnUrl: state.url }});
        return false;
    }
}
