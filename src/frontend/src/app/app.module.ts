import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

/* SERVICES AND UTILS */
import { AuthService } from './services/auth.service';

import { JwtUtil } from './utils/jwt.util';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
  ],
  providers: [  
    AuthService,
    JwtUtil
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
