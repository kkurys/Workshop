import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { CarHelpEntryResponse } from '../models/responses/car-help-entry-response.model';

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

        return this.http.get<CarHelpEntryResponse>(url, { params: params, headers: this.headers });
    }
}