import { CarHelpEntry } from '../car-help-entry.model';

export class CarResponse {
    constructor(
        public carHelpEntries: CarHelpEntry[]) { }
}