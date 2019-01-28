import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
import { Car } from 'src/app/models/car.model';
import { Router } from '@angular/router';
import { RolesUtil } from 'src/app/utils/roles.util';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
    cars: Car[] = [];

    constructor(
        private carService: CarService, 
        private router: Router,
        private rolesUtil: RolesUtil
    ) { }

    ngOnInit() {
        this.getCars();
    }

    getCars() {
        if (this.canManage()){
            this.carService
                .getCars(Number.MAX_VALUE, 0)
                .subscribe(response => {
                    this.cars = response.cars;
                });
        } else {
            this.carService
                .getUserCars(Number.MAX_VALUE, 0)
                .subscribe(response => {
                    this.cars = response.cars;
                });
        }
    }

    carSelected(id) {
        this.router.navigateByUrl('car/' + id);
    }

    canManage() {
        return this.rolesUtil.isInRole("Manager");
    }
}
