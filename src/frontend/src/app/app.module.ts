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

import { MessageSnackBarComponent } from './components/message-snack-bar/message-snack-bar.component';

/* SERVICES */
import { AuthService } from './services/auth.service';
import { CarService } from './services/car.service';

/* UTILS */
import { RolesUtil } from './utils/roles.util';
import { JwtUtil } from './utils/jwt.util';
import { CarComponent } from './components/car/car.component';
import { AuthGuard } from './utils/auth-guard.util';
import { ManagerGuard } from './utils/manager-guard.util';
import { ClientGuard } from './utils/client-guard.util';
import { AdminGuard } from './utils/admin-guard.util';


const appRoutes: Routes = [
	{ path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
	{ path: 'login', component: LoginComponent },
	{ path: 'cars', component: CarsComponent, canActivate: [ManagerGuard] },
	{ path: 'car/:id', component: CarComponent, canActivate: [ManagerGuard] },
	{ path: 'car', component: CarComponent, canActivate: [ManagerGuard] }

];

@NgModule({
	declarations: [
		AppComponent,
		NavMenuComponent,
		LoginComponent,
		HomeComponent,
		MessageSnackBarComponent,
		CarsComponent,
		CarComponent
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
		JwtUtil,
		RolesUtil
	],
	entryComponents: [
		MessageSnackBarComponent
	],
	bootstrap: [AppComponent]
})

export class AppModule { }
