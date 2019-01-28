import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { FormGroup, Validators, FormBuilder, FormControl, FormGroupDirective, NgForm } from '@angular/forms';
import { ErrorStateMatcher, MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { MessageSnackBarComponent } from '../message-snack-bar/message-snack-bar.component';

export class MyErrorStateMatcher implements ErrorStateMatcher {
	isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
		const invalidCtrl = !!(control && control.invalid && control.parent.dirty);
		const invalidParent = !!(control && control.parent && control.parent.invalid && control.parent.dirty);

		return (invalidCtrl || invalidParent);
	}
}

@Component({
	selector: 'login-root',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.css']
})
export class LoginComponent {
	loginForm: FormGroup;
	registerForm: FormGroup;
	matcher = new MyErrorStateMatcher();

	loginMessage: String;
	registerMessage: String;

	constructor(
		private authService: AuthService,
		private formBuilder: FormBuilder,
		private router: Router,
		private snackBar: MatSnackBar) {

		this.loginForm = this.formBuilder.group({
			login: [
				'',
				[Validators.required]
			],
			password: [
				'',
				[Validators.required]
			]
		});

		this.registerForm = this.formBuilder.group({
			login: [
				'',
				[Validators.required]
			],
			password: [
				'',
				[Validators.required]
			],
			confirmPassword: [
				'',
				[Validators.required]
			],
			email: [
				'',
				[Validators.required, Validators.email]
			],
			firstName: [
				'',
				[Validators.required]
			],
			lastName: [
				'',
				[Validators.required]
			],
		}, {
				validator: this.checkPasswords
			});
	}

	login() {
		this.authService
			.login(
				this.loginForm.controls.login.value, 
				this.loginForm.controls.password.value)
			.subscribe(result => {
				localStorage.setItem('token', result);
				this.router.navigateByUrl('');
			}, error =>
				this.snackBar
					.openFromComponent(
						MessageSnackBarComponent,
						{
							data: {
								message: 'Login lub hasło są niepoprawne',
								messageType: 'danger'
							}
						})
			);
	}

	register() {
		this.authService
			.register(
				this.registerForm.controls.email.value,
				this.registerForm.controls.login.value, 
				this.registerForm.controls.password.value,
				this.registerForm.controls.firstName.value,
				this.registerForm.controls.lastName.value)
			.subscribe(result => {
				localStorage.setItem('token', result);
				this.router.navigateByUrl('');
			}, error =>
				this.snackBar
					.openFromComponent(
						MessageSnackBarComponent,
						{
							data: {
								message: 'Podane są niepoprawne lub login jest już zajęty',
								messageType: 'danger'
							}
						})
			);
	}

	checkPasswords(group: FormGroup) {
		let password = group.controls.password.value;
		let confirmPassword = group.controls.confirmPassword.value;

		return password === confirmPassword ? null : { notSame: true }
	}
}
