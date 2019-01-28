import { Component } from '@angular/core';
import { RolesUtil } from '../../utils/roles.util';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
    constructor(
        private rolesUtil: RolesUtil) { }

    ngOnInit() {

    }
}
