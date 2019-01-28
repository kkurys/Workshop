export class UpdateCarRequest {
    constructor(
        public id: string,
        public year: number, 
        public model: string,
        public description: string) { }
}