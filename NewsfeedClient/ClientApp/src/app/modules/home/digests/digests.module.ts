import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../../shared/material.module';
import { DigestsRoutingModule } from './digests-routing.module';
import { FlexLayoutModule } from '@angular/flex-layout';

import { UsersService } from '../../../shared/services/users.service';
import { DigestsService } from '../../../shared/services/digests.service';
import { SubscriptionsService } from '../../../shared/services/subscriptions.service';

import { DigestsComponent } from './digests/digests.component';
import { DigestsListComponent } from './digests-list/digests-list.component';
import { DigestCardComponent } from './digest-card/digest-card.component';
import { SubscriptionsListComponent } from './subscriptions-list/subscriptions-list.component';
import { SubscriptionCardComponent } from './subscription-card/subscription-card.component';


@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    MaterialModule,
    DigestsRoutingModule,
    FlexLayoutModule
  ],
  declarations: [
    DigestsComponent,
    DigestsListComponent,
    DigestCardComponent,
    SubscriptionsListComponent,
    SubscriptionCardComponent
  ],
  providers: [
    UsersService,
    DigestsService,
    SubscriptionsService
  ]
})
export class DigestsModule {
}

export function exportDigestsModule() {
  return DigestsModule;
}
