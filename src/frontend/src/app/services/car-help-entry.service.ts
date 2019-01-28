import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { CarsResponse } from '../models/responses/cars-response.model';
import { CarResponse } from '../models/responses/car-response.model';
import { UpdateCarRequest } from '../models/requests/update-car-request.model';
import { CreateCarRequest } from '../models/requests/create-car-request.model';

@Injectable()
export class CarHelpEntryService extends BaseService {
    
    constructor(http: HttpClient) {
        super(http);
    }

    getCarHelpEntries(id, take, skip) {
        let url = this.baseUrl + 'CarHelpEntry/GetCarHelpEntries';

        let params = new HttpParams()
            .set("id", id)
            .set("take", take)
            .set("skip", skip);

        return this.http.get<CarsResponse>(url, { params: params, headers: this.headers });
    }

    getCarById(id) {
        let url = this.baseUrl + 'Car/GetCarById';

        let params = new HttpParams()
            .set("id", id);

        return this.http.get<CarResponse>(url, { params: params, headers: this.headers });
    }

    updateCar(year: number, model: string, description: string) {
        let updateCarModel = new UpdateCarRequest(year, model, description);
        let url = this.baseUrl + 'Car/UpdateCar';

        return this.http.post<CarResponse>(url, updateCarModel);
    }

    createCar(year: number, model: string, description: string) {
        let createCarModel = new CreateCarRequest(year, model, description);
        let url = this.baseUrl + 'Car/CreateCar';

        return this.http.post<CarResponse>(url, createCarModel);
    }
}