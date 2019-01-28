export class Log {
    constructor(
        public occurence: Date,
        public exception: string,
        public stackTrace: string) { }
}