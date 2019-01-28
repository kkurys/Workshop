import { Inject, Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';


@Injectable()
export class BaseService {
    protected headers: HttpHeaders;
    protected http: HttpClient;
    protected baseUrl: string;

    constructor(http: HttpClient) {
        this.headers = new HttpHeaders({
            'Authorization': 'Bearer ' + localStorage.getItem('token')
        });

        this.http = http;
        this.baseUrl = environment.baseUrl + '/api/';
    }
}