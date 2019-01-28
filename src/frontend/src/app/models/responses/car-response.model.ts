import { Car } from '../car.model';

export class CarResponse {
    constructor(
        public totalCount: number,
        public cars: Car[]) { }
}