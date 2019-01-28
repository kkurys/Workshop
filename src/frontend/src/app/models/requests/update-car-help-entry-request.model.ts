export class UpdateCarHelpEntryRequest {
    constructor(
        public CarHelpId: string,
        public Name: string,
        public Description: string,
        public Price: number,
        public Status: number) { }
}