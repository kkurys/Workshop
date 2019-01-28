import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { RolesUtil } from '../../utils/roles.util';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
    constructor(private router: Router,
        private roles: RolesUtil) {
    }

    isExpanded = false;

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }

    logout() {
        localStorage.clear();
        this.router.navigateByUrl('/login');
    }

    isAdmin() {
        return this.roles.isInRole('Admin');
    }

    isManager() {
        return this.roles.isInRole('Manager');
    }

    isClient() {
        return this.roles.isInRole('Client');
    }
}
