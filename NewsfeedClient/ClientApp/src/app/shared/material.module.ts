import { NgModule } from '@angular/core';
import {MatButtonModule, MatCheckboxModule, MatInputModule, MatSelectModule, MatIconModule,MatSidenavModule, MatListModule, MatToolbarModule, MatTabsModule, MatCardModule, MatSnackBarModule, MatExpansionModule, MatDialogModule} from '@angular/material';


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
    MatExpansionModule,
    MatDialogModule
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
    MatExpansionModule,
    MatDialogModule
  ]
})

export class MaterialModule {
} 
