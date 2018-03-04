import { Component, Input } from '@angular/core';
import { Digest } from '../../../../shared/models/digest';

@Component({
    selector: 'digests-subscription-card',
    templateUrl: './subscription-card.component.html',
    styleUrls: ['./subscription-card.component.css']
})

export class SubscriptionCardComponent {
    @Input() public subscription: Digest;

    constructor() {

    }
}
