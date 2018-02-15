import { Injectable } from '@angular/core';

@Injectable()
export class Post {

  constructor(
    public timePosted: Date,  
    public content: string,
    public attachments: object[],
    public id?: number) {
  }
}
