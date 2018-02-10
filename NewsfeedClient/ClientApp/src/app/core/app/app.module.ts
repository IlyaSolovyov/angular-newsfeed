import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { MaterialModule } from '../../shared/material.module';

import { PostsService } from '../../shared/services/posts.service';

import { AppComponent } from './app.component';
import { NavComponent } from '../nav/nav.component';
import { HomeComponent } from '../../modules/page/home/home.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavComponent  
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MaterialModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [PostsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
