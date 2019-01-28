export class CarHelpEntry {
    constructor(
        public id: String, 
        public name: String,
        public description: String,
        public created: Date,
        public updated: Date,
        public status: String,
        public price: Number,
        public EmployeeId: String,
        public EmployeeName: String) { }
}