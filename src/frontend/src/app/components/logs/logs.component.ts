import { Component } from '@angular/core';
import { LoggingService } from '../../services/logging.service';
import { LogsResponse } from '../../models/responses/logs-response.model';
import { TimeUtil } from 'src/app/utils/time.util';


@Component({
  selector: 'app-logs',
  templateUrl: './logs.component.html'
})
export class LogsComponent {

    loggingListing: LogsResponse = { totalCount: 0, logs: []};
    
    constructor(
        private loggingService: LoggingService,
        private timeUtil: TimeUtil) { }

    ngOnInit() {
        this.getLogs(0, 10);
    }

    getLogs(skip, take) {
        this.loggingService
            .getLogs(skip, take)
            .subscribe(response => {
                this.loggingListing = response;
            });
    }
}
