import { Component, Inject } from '@angular/core';
import { Source } from '../../../../shared/models/source';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { DigestsService } from '../../../../shared/services/digests.service';
import { Digest } from '../../../../shared/models/digest';
import { FormControl, Validators } from '@angular/forms';
import { CommunicationService } from '../../../../shared/services/communication.service';

@Component({
    selector: 'digests-source-list-edit',
    templateUrl: './source-list-edit.component.html',
    styleUrls: ['./source-list-edit.component.css']
})

export class SourceListEditComponent {

    sources: Source[];
    digestId: number;

    name: string;
    service: string;
    url: string;
    nameFormControl = new FormControl('', [Validators.required]);
    serviceFormControl = new FormControl('', [Validators.required]);
    urlFormControl = new FormControl('', [Validators.required]);

    constructor(public dialogRef: MatDialogRef<SourceListEditComponent>, private snackBar: MatSnackBar,
      @Inject(MAT_DIALOG_DATA) public data: any, private digestsService: DigestsService,
      private communicationService: CommunicationService) { }

    ngOnInit() {
      this.digestId = this.data.digestId;
      console.log(this.data);
      this.fetchSources(this.digestId);
      this.communicationService.sourcesUpdateNeeded
        .subscribe(result => this.updateSources(result, this.digestId));
    }

    getNameErrorMessage() {
      return this.nameFormControl.hasError('required') ? 'This field is required' :
        '';
    }

    getServiceErrorMessage() {
      return this.serviceFormControl.hasError('required') ? 'This field is required' :
        '';
    }

    getUrlErrorMessage() {
      return this.urlFormControl.hasError('required') ? 'This field is required' :
        '';
    }

    updateSources(trigger: boolean, digestId: number) {
      if (trigger == true) {
        console.log("Update found!");
        this.fetchSources(digestId);
        this.communicationService.confirmSourcesUpdate();
      }
    }

    fetchSources(digestId: number) {
      this.digestsService.getDigestData(digestId)
        .subscribe((digest:Digest) => {
          this.sources = digest.sources;
        })
    }

    addSource(digestId: number, name: string, service: string, url: string) {
      console.log("adding source");
      this.digestsService.addSourceToDigest(digestId, name, service, url)
        .subscribe((response: string) => {
          console.log("source added");
          this.snackBar.open(response, 'Okay', {
            duration: 5000,
          });

          this.fetchSources(digestId);
        });
    }

}
