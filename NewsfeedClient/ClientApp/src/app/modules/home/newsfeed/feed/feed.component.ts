import { Component, Input } from '@angular/core';

@Component({
    selector: 'newsfeed-feed',
    templateUrl: './feed.component.html',
    styleUrls: ['./feed.component.css']
})

export class FeedComponent {
    @Input() public category: string;
}
