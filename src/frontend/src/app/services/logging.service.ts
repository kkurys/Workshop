import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { BaseService } from './base.service';
import { LogsResponse } from '../models/responses/logs-response.model';


@Injectable()
export class LoggingService extends BaseService {
    
    constructor(http: HttpClient) {
        super(http);
    }

    getLogs(skip, take) {
        let url = this.baseUrl + 'Logging/GetLogs';

        let params = new HttpParams()
            .set("take", take)
            .set("skip", skip);

        return this.http.get<LogsResponse>(url, { params: params, headers: this.headers });
    }
}