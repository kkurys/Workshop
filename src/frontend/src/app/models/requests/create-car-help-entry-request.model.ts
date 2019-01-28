export class CreateCarHelpEntryRequest {
    constructor(
        public CarId: string, 
        public Name: string,
        public Description: string,
        public Price: number,
        public Status: number) { }
}