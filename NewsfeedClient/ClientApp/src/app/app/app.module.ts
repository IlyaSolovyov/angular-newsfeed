import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../shared/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeModule } from '../modules/home/home.module';
import { AccountModule } from '../modules/account/account.module';
import { AppRoutingModule } from './app-routing.module';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AnonymousGuard } from '../shared/guards/anonymous.guard';
import { AuthGuard } from '../shared/guards/auth.guard';

import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { CommunicationService } from '../shared/services/communication.service';


@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    MaterialModule,
    HomeModule,
    AccountModule,
    FlexLayoutModule,
    AppRoutingModule
  ],
  providers: [
    AuthGuard,
    AnonymousGuard,
    CommunicationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
