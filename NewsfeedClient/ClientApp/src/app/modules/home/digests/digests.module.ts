import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
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
import { DigestsHubComponent } from './digests-hub/digests-hub.component';
import { DigestCreationComponent } from './digest-creation/digest-creation.component';
import { SourceListEditComponent } from './source-list-edit/source-list-edit.component';
import { SourceCardComponent } from './source-card/source-card.component';



@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    DigestsRoutingModule,
    FlexLayoutModule
  ],
  declarations: [
    DigestsComponent,
    DigestsHubComponent,
    DigestsListComponent,
    DigestCardComponent,
    SubscriptionsListComponent,
    SubscriptionCardComponent,
    DigestCreationComponent,
    SourceListEditComponent,
    SourceCardComponent
  ],
  providers: [
    UsersService,
    DigestsService,
    SubscriptionsService
  ],
  entryComponents: [
    DigestCreationComponent,
    SourceListEditComponent
  ]
})
export class DigestsModule {
}

export function exportDigestsModule() {
  return DigestsModule;
}
