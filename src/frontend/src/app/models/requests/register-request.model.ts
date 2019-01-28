export class RegisterRequest {
    constructor(
        public Email: string, 
        public UserName: string,
        public Password: string,
        public FirstName: string,
        public LastName: string) { }
}