import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { CarResponse } from '../models/responses/car-response.model';

@Injectable()
export class CarService extends BaseService {
    
    constructor(http: HttpClient) {
        super(http);
    }

    getCars(take, skip) {
        let url = this.baseUrl + 'Car/GetCars';

        let params = new HttpParams()
            .set("take", take)
            .set("skip", skip);

        return this.http.get<CarResponse>(url, { params: params, headers: this.headers });
    }
}