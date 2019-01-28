import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
import { getLocalRefs } from '@angular/core/src/render3/discovery_utils';
import { Car } from 'src/app/models/car.model';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CarHelpEntry } from 'src/app/models/car-help-entry.model';
import { CarHelpEntryService } from 'src/app/services/car-help-entry.service';

import * as moment from 'moment';
import { TimeUtil } from 'src/app/utils/time.util';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {
    private sub: any;
    id: number;
    edit: Boolean;
    form: FormGroup;
    car: Car;
    carHelpEntires: CarHelpEntry[];

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private formBuilder: FormBuilder,
        private carService: CarService,
        private carHelpEntryService: CarHelpEntryService,
        private timeUtil: TimeUtil
    ) {
        
		this.form = this.formBuilder.group({
			year: [
				new Date().getFullYear(),
				[
                    Validators.required, 
                    Validators.min(1885), 
                    Validators.max(new Date().getFullYear())
                ]
			],
			model: [
				'',
				[ Validators.required ]
			],
			description: [
				'',
			]
		});
    }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.id = params['id'];

            if (this.id === undefined) {
                this.edit = false;
            } else {
                this.edit = true;
                this.getCar(this.id);
                this.getCarHelpEntires(this.id);
            }
        });
    }

    getCar(id: number) {
        this.carService
            .getCarById(this.id)
            .subscribe(response => {
                this.car = response.car;
                this.form.controls.year.setValue(this.car.year);
                this.form.controls.model.setValue(this.car.model);
                this.form.controls.description.setValue(this.car.description);
            });
    }

    getCarHelpEntires(carId: number) {
        this.carHelpEntryService
            .getCarHelpEntries(carId, Number.MAX_VALUE, 0)
            .subscribe(response => {
                this.carHelpEntires = response.carHelpEntries;
            });
    }

    backToList() {
        this.router.navigateByUrl('cars');
    }

    submit() {
        if (this.edit) {
            this.carService
                .updateCar(
                    this.form.controls.year.value,
                    this.form.controls.model.value,
                    this.form.controls.description.value
                )
                .subscribe(response => {
				    this.router.navigateByUrl('cars');
                });
        } else {
            this.carService
                .createCar(
                    this.form.controls.year.value,
                    this.form.controls.model.value,
                    this.form.controls.description.value
                )
                .subscribe(response => {
                    this.router.navigateByUrl('cars');
                });
        }
    }
}
