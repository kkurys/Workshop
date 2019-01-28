import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { CarsResponse } from '../models/responses/cars-response.model';
import { CarResponse } from '../models/responses/car-response.model';
import { UpdateCarRequest } from '../models/requests/update-car-request.model';
import { CreateCarRequest } from '../models/requests/create-car-request.model';
import { DeleteCarRequest } from '../models/requests/delete-car-request.model';

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

        return this.http.get<CarsResponse>(url, { params: params, headers: this.headers });
    }

    getUserCars(take, skip) {
        let url = this.baseUrl + 'Car/GetUserCars';

        let params = new HttpParams()
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

    updateCar(id: string, year: number, model: string, description: string) {
        let updateCarModel = new UpdateCarRequest(id, year, model, description);
        let url = this.baseUrl + 'Car/UpdateCar';

        return this.http.put<CarResponse>(url, updateCarModel, { headers: this.headers });
    }

    createCar(year: number, model: string, description: string) {
        let createCarModel = new CreateCarRequest(year, model, description);
        let url = this.baseUrl + 'Car/CreateCar';

        return this.http.post<CarResponse>(url, createCarModel, { headers: this.headers });
    }

    deleteCar(id) {
        let deleteCarModel = new DeleteCarRequest(id);
        let url = this.baseUrl + 'Car/DeleteCar';

        let params = new HttpParams()
            .set("id", id);

        return this.http.post(url, deleteCarModel, { headers: this.headers });
    }
}