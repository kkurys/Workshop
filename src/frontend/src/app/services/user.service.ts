import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { UsersResponse } from '../models/responses/users-response.model';


@Injectable()
export class UserService extends BaseService {
    
    constructor(http: HttpClient) {
        super(http);
    }

    getUsers() {
        let url = this.baseUrl + 'User/GetUsers';

        let params = new HttpParams();

        return this.http.get<UsersResponse>(url, { params: params, headers: this.headers });
    }
}