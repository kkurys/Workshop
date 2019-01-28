import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { JwtUtil } from '../utils/jwt.util';

import { LoginRequest } from '../models/requests/login-request.model';
import { RegisterRequest } from '../models/requests/register-request.model';
import { BaseService } from './base.service';

@Injectable()
export class AuthService extends BaseService {
    
    constructor(http: HttpClient, private jwtUtil: JwtUtil) {
        super(http);
    }

    login(login: string, password: string) {
        let loginModel = new LoginRequest(login, password);
        let url = this.baseUrl + 'Auth/Login';

        return this.http.post<string>(url, loginModel);
    }

    register(email: string, login: string, password: string, firstName: string, lastName: string) {
        let registerModel = new RegisterRequest(email, login, password, firstName, lastName);
        let url = this.baseUrl + 'Auth/Register';

        return this.http.post<string>(url, registerModel);
    }

    isLoggedIn() {
        const token = localStorage.getItem('token');

        if (token != null) {
            const decodedToken = this.jwtUtil.decode(localStorage.getItem('token'));
            const currentUnixTimestamp = Math.round((new Date()).getTime() / 1000);

            if (decodedToken.exp > currentUnixTimestamp) {
                return true;
            }
        }
        
        return false;
    }
}