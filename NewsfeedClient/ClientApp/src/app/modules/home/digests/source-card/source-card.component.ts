import { Component, Input } from '@angular/core';
import { Source } from '../../../../shared/models/source';
import { DigestsService } from '../../../../shared/services/digests.service';
import { MatSnackBar } from '@angular/material';
import { CommunicationService } from '../../../../shared/services/communication.service';

@Component({
    selector: 'digests-source-card',
    templateUrl: './source-card.component.html',
    styleUrls: ['./source-card.component.css']
})

export class SourceCardComponent {
    @Input() public source: Source;
    @Input() public digestId: number;
    constructor(private digestsService: DigestsService, private snackBar: MatSnackBar,
      private communicationService: CommunicationService) { }

    removeSource(digestId:number, sourceId: number) {
      console.log("removing source " + sourceId + " from digest " + digestId)
      this.digestsService.removeSourceFromDigest(digestId, sourceId)
        .subscribe((response: string) => {

        this.snackBar.open(response, 'Okay', {
          duration: 5000,
        });

        this.communicationService.triggerSourcesUpdate();
      });;
    }
}
