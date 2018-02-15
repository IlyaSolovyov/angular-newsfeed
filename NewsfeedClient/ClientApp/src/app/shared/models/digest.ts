import { Injectable } from '@angular/core';
import { User } from './user';

@Injectable()
export class Digest {

  constructor(
    public name: string,
    public content: string,
    public creator: User,
    public isPublic: boolean,
    public posts: object[],
    public id?: number) {
  }
}
