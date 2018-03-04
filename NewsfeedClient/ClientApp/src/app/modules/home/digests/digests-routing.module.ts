import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DigestsComponent } from './digests/digests.component';
import { DigestsHubComponent } from './digests-hub/digests-hub.component';


const digestsRoutes: Routes = [
  {
    path: '', component: DigestsComponent,
    children: [
      { path: '', component: DigestsHubComponent }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(digestsRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class DigestsRoutingModule {
}
