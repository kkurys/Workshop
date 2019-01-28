import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { CarHelpEntryService } from 'src/app/services/car-help-entry.service';
import { CarHelpEntry } from 'src/app/models/car-help-entry.model';
import { Location } from '@angular/common';
import { StatusesUtil } from 'src/app/utils/statuses.util';

@Component({
  selector: 'app-car-help-entry',
  templateUrl: './car-help-entry.component.html',
  styleUrls: ['./car-help-entry.component.css']
})
export class CarHelpEntryComponent implements OnInit {
    private sub: any;
	id: number;
	carId: number;
    edit: Boolean;
	form: FormGroup;
	carHelpEntry: CarHelpEntry;


    constructor(
        private route: ActivatedRoute,
		private formBuilder: FormBuilder,
		private carHelpEntryService: CarHelpEntryService,
		private location: Location,
		private statusesUtil: StatusesUtil
    ) { 
		
		this.form = this.formBuilder.group({
			name: [
				'',
				[ Validators.required ]
			],
			description: [
				'',
				[ Validators.required ]
			],
			price: [
				1,
				[ Validators.min(1) ]
			],
			status: [
				0,
				[ Validators.required ]
			]
		});
	}

    ngOnInit() {
		this.sub = this.route.params.subscribe(params => {
            this.id = params['id'];
			this.carId = params['carId'];

            if (this.id === undefined) {
                this.edit = false;
            } else {
				this.edit = true;
				this.getCarHelpEntry(this.id);
            }
        });
	}
	
	getCarHelpEntry(carHelpId: number) {
		this.carHelpEntryService
			.getCarHelpEntryById(carHelpId)
			.subscribe(response => {
				this.carHelpEntry = response.carHelpEntry;
                this.form.controls.name.setValue(this.carHelpEntry.name);
                this.form.controls.description.setValue(this.carHelpEntry.description);
                this.form.controls.price.setValue(this.carHelpEntry.price);
                this.form.controls.status.setValue(this.carHelpEntry.status);
			});
	}

	submit() {
		if (this.edit) {
			this.carHelpEntryService
				.updateCarHelpEntry(
					this.id,
					this.form.controls.name.value,
					this.form.controls.description.value,
					this.form.controls.price.value,
					this.form.controls.status.value
				)
				.subscribe(response => {
					this.goBack();
				});
		} else {
			this.carHelpEntryService
				.createCarHelpEntry(
					this.carId,
					this.form.controls.name.value,
					this.form.controls.description.value,
					this.form.controls.price.value,
					this.form.controls.status.value
				)
				.subscribe(response => {
					this.goBack();
				});
		}
	}

	goBack() {
		this.location.back();
	}
}
