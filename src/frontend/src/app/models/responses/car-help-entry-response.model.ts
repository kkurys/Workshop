import { CarHelpEntry } from '../car-help-entry.model';

export class CarHelpEntryResponse {
    constructor(
        public carHelpEntries: CarHelpEntry[]) { }
}