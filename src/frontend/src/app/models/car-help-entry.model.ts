export class CarHelpEntry {
    constructor(
        public id: String, 
        public name: String,
        public description: String,
        public createdOn: Date,
        public updatedOn: Date,
        public status: String,
        public price: Number,
        public EmployeeId: String,
        public EmployeeName: String) { }
}