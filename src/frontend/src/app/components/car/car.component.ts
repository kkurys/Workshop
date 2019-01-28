import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
import { getLocalRefs } from '@angular/core/src/render3/discovery_utils';
import { Car } from 'src/app/models/car.model';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit {
    private sub: any;
    id: number;

    constructor(
        private route: ActivatedRoute,
        private router: Router
    ) { }

    ngOnInit() {
        this.sub = this.route.params.subscribe(params => {
            this.id = params['id'];

            console.log(this.id);
            
            this.getCar(0);
        });
    }

    getCar(id: number) {
        
    }
}
