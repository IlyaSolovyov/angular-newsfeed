import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../shared/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeModule } from '../modules/home/home.module';
import { AccountModule } from '../modules/account/account.module';
import { AppRoutingModule } from './app-routing.module';

import { AuthGuard } from '../shared/guards/auth.guard';
import { PostsService } from '../shared/services/posts.service';

import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';


@NgModule({
  declarations: [
    AppComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MaterialModule,
    HomeModule,
    AccountModule,
    AppRoutingModule
  ],
  providers: [PostsService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
