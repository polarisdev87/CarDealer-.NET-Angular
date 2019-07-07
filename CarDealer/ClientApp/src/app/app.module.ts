import { NgModule } from '@angular/core';
import { ErrorHandler } from "@angular/core";
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { ToastyModule } from 'ng2-toasty';

import { VehicleService } from './services/vehicle.service';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { VehicleFormComponent } from './components/vehicle-form/vehicle-form.component';
import Apperrorhandler = require("./app.error-handler");
import AppErrorHandler = Apperrorhandler.AppErrorHandler;


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavigationComponent,
    VehicleFormComponent
    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpModule,
    HttpClientModule,
    FormsModule,
    ToastyModule.forRoot(),
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'vehicles/new', component: VehicleFormComponent }
    ])
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler},
    VehicleService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
