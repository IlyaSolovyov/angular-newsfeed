import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DigestsComponent } from './digests/digests.component';


const digestsRoutes: Routes = [
  {
    path: '', component: DigestsComponent,
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
