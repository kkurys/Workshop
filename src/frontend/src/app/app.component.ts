import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'frontend';
  constructor(private authService: AuthService)  {

  }
  ngOnInit() {
    this.authService.login("admin", "Haslo123.").subscribe(x => console.log(x));
  }
}
