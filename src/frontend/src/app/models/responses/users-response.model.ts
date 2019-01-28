import { User } from '../user.model';

export class UsersResponse {
    constructor(
        public cars: User[]) { }
}