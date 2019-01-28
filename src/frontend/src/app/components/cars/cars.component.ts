import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
import { Car } from 'src/app/models/car.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.css']
})
export class CarsComponent implements OnInit {
    cars: Car[];

    constructor(
        private carService: CarService, 
        private router: Router
    ) { }

    ngOnInit() {
        this.getCars();
    }

    getCars() {
        this.carService
            .getCars(10, 0)
            .subscribe(response => {
                this.cars = response.cars;
            });
    }

    carSelected(id) {
        this.router.navigateByUrl('car/' + id);
    }
}
