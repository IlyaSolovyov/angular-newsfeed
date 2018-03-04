import { NgModule } from '@angular/core';
import {MatButtonModule, MatCheckboxModule, MatInputModule, MatSelectModule, MatIconModule,MatSidenavModule, MatListModule, MatToolbarModule, MatTabsModule, MatCardModule, MatSnackBarModule, MatExpansionModule} from '@angular/material';


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
    MatSnackBarModule,
    MatExpansionModule
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
    MatSnackBarModule,
    MatExpansionModule
  ]
})

export class MaterialModule {
} 
