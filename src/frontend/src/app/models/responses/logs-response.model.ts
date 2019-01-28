import { Log } from '../log.model';

export class LogsResponse {
    constructor(
        public totalCount: number,
        public logs: Log[]) { }
}