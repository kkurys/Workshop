import { Car } from '../car.model';

export class CarsResponse {
    constructor(
        public totalCount: number,
        public cars: Car[]) { }
}