import { Injectable } from '@angular/core';

@Injectable()
export class Post {

  constructor(
    public category: string,
    public source: string,
    public timePosted: Date,
    public author: string,
    public content: string,
    public attachments: object[],
    public id?: number) {
  }
}
