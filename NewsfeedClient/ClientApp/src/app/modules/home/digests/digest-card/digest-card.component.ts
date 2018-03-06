import { Component, Input } from '@angular/core';
import { Digest } from '../../../../shared/models/digest';

@Component({
    selector: 'digests-digest-card',
    templateUrl: './digest-card.component.html',
    styleUrls: ['./digest-card.component.css']
})

export class DigestCardComponent {
    @Input() public digest: Digest;
    @Input() public subscribed: boolean;
    constructor() {

    }
}
