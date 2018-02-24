import { Injectable } from '@angular/core';
import { Source } from './source';

@Injectable()
export class Post {

  constructor(
    public timePosted: Date,
    public source: Source,
    public content: string,
    public attachments: object[],
    public id: number) {
  }
}
