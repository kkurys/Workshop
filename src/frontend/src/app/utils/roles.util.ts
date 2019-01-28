import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { JwtUtil } from '../utils/jwt.util';

@Injectable()
export class RolesUtil {

    constructor(private jwtUtil: JwtUtil) { }

    isInRole(roleName) {
        let decodedToken = this.jwtUtil.decode(localStorage.getItem('token'));

        return decodedToken.role.toLowerCase() === roleName.toLowerCase();
    }
}