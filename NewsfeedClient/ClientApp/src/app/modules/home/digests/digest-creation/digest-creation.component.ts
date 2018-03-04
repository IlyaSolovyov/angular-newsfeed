import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
    selector: 'digests-digest-creation',
    templateUrl: './digest-creation.component.html',
    styleUrls: ['./digest-creation.component.css']
})

export class DigestCreationComponent {

  constructor(
    public dialogRef: MatDialogRef<DigestCreationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  cancel(): void {
    this.dialogRef.close();
  }
}
