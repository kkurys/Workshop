export class CreateCarRequest {
    constructor(
        public Year: number, 
        public Model: string,
        public Description: string) { }
}