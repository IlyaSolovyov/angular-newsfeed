import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../../shared/material.module';
import { DigestsRoutingModule } from './digests-routing.module';

import { DigestsComponent } from './digests/digests.component';

import { UsersService } from '../../../shared/services/users.service';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    DigestsRoutingModule
  ],
  declarations: [
    DigestsComponent
  ],
  providers: [
    UsersService
  ]
})
export class DigestsModule {
}

export function exportDigestsModule() {
  return DigestsModule;
}
