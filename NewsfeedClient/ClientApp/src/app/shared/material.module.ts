import { NgModule } from '@angular/core';
import {
  MatButtonModule, MatCheckboxModule, MatInputModule, MatSelectModule, MatIconModule,
  MatSidenavModule, MatListModule, MatToolbarModule, MatTabsModule, MatCardModule,
  MatSnackBar
} from '@angular/material';


@NgModule({
  imports: [
    MatButtonModule,
    MatCheckboxModule,
    MatInputModule,
    MatSelectModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    MatTabsModule,
    MatCardModule,
    MatSnackBar
  ],
  exports: [
    MatButtonModule,
    MatCheckboxModule,
    MatInputModule,
    MatSelectModule,
    MatIconModule,
    MatSidenavModule,
    MatListModule,
    MatToolbarModule,
    MatTabsModule,
    MatCardModule,
    MatSnackBar
  ]
})

export class MaterialModule {
} 
