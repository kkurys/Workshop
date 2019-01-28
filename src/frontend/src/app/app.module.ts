/* MODULES */
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { MaterialModule } from './material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';

/* COMPONENTS */
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { CarsComponent } from './components/cars/cars.component';
import { CarComponent } from './components/car/car.component';
import { CarHelpEntryComponent } from './components/car-help-entry/car-help-entry.component';
import { LogsComponent } from './components/logs/logs.component';
import { MessageSnackBarComponent } from './components/message-snack-bar/message-snack-bar.component';

/* SERVICES */
import { AuthService } from './services/auth.service';
import { CarService } from './services/car.service';
import { CarHelpEntryService } from './services/car-help-entry.service';
import { LoggingService } from './services/logging.service';

/* UTILS */
import { RolesUtil } from './utils/roles.util';
import { JwtUtil } from './utils/jwt.util';
import { AuthGuard } from './utils/auth-guard.util';
import { ManagerGuard } from './utils/manager-guard.util';
import { ClientGuard } from './utils/client-guard.util';
import { AdminGuard } from './utils/admin-guard.util';
import { TimeUtil } from './utils/time.util';
import { StatusesUtil } from './utils/statuses.util';


const appRoutes: Routes = [
	{ path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
	{ path: 'login', component: LoginComponent },
	{ path: 'cars', component: CarsComponent, canActivate: [AuthGuard] },
	{ path: 'car/:id', component: CarComponent, canActivate: [AuthGuard] },
	{ path: 'car', component: CarComponent, canActivate: [AuthGuard] },
	{ path: 'car-help-entry/:id', component: CarHelpEntryComponent, canActivate: [ManagerGuard] },
	{ path: 'car-help-entry/:carId', component: CarHelpEntryComponent, canActivate: [ManagerGuard] },
	{ path: 'car-help-entry', component: CarHelpEntryComponent, canActivate: [ManagerGuard] },
	{ path: 'logs', component: LogsComponent, canActivate: [AdminGuard]}

];

@NgModule({
	declarations: [
		AppComponent,
		NavMenuComponent,
		LoginComponent,
		HomeComponent,
		MessageSnackBarComponent,
		CarsComponent,
		CarComponent,
		CarHelpEntryComponent,
		LogsComponent
	],
	imports: [
		BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
		RouterModule.forRoot(
			appRoutes
		),
		MaterialModule,
		BrowserModule,
		AppRoutingModule,
		HttpClientModule,
		FormsModule,
		ReactiveFormsModule
	],
	providers: [
		AuthGuard,
		AdminGuard,
		ManagerGuard,
		ClientGuard,
		AuthService,
		CarService,
		CarHelpEntryService,
		JwtUtil,
		RolesUtil,
		TimeUtil,
		StatusesUtil,
		LoggingService
	],
	entryComponents: [
		MessageSnackBarComponent
	],
	bootstrap: [AppComponent]
})

export class AppModule { }
