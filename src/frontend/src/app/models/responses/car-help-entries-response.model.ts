import { CarHelpEntry } from '../car-help-entry.model';

export class CarHelpEntriesResponse {
    constructor(
        public carHelpEntries: CarHelpEntry[]) { }
}