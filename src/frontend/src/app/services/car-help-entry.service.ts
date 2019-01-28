import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { CarHelpEntriesResponse } from '../models/responses/car-help-entries-response.model';
import { CarHelpEntryResponse } from '../models/responses/car-help-entry-response.model';
import { CreateCarHelpEntryRequest } from '../models/requests/create-car-help-entry-request.model';
import { UpdateCarHelpEntryRequest } from '../models/requests/update-car-help-entry-request.model';

@Injectable()
export class CarHelpEntryService extends BaseService {
    
    constructor(http: HttpClient) {
        super(http);
    }

    getCarHelpEntries(carId, take, skip) {
        let url = this.baseUrl + 'CarHelpEntry/GetCarHelpEntries';

        let params = new HttpParams()
            .set("carId", carId)
            .set("take", take)
            .set("skip", skip);

        return this.http.get<CarHelpEntriesResponse>(url, { params: params, headers: this.headers });
    }

    getCarHelpEntryById(id) {
        let url = this.baseUrl + 'CarHelpEntry/GetCarHelpEntryById';

        let params = new HttpParams()
            .set("id", id);

        return this.http.get<CarHelpEntryResponse>(url, { params: params, headers: this.headers });
    }

    createCarHelpEntry(carId, name, description, price, status) {
        let createCarHelpEntryModel = new CreateCarHelpEntryRequest(carId, name, description, price, status);
        let url = this.baseUrl + 'CarHelpEntry/CreateCarHelpEntry';

        return this.http.post(url, createCarHelpEntryModel, { headers: this.headers });
    }

    updateCarHelpEntry(carHelpId, name, description, price, status) {
        let updateCarHelpEntryModel = new UpdateCarHelpEntryRequest(carHelpId, name, description, price, status);
        let url = this.baseUrl + 'CarHelpEntry/UpdateCarHelpEntry';

        return this.http.put(url, updateCarHelpEntryModel, { headers: this.headers });
    }
}