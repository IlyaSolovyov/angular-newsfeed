import { Injectable } from '@angular/core';
import { User } from './user';

@Injectable()
export class Digest {

  constructor(
    public name: string,
    public creator: string,
    public isPublic: boolean,
    public id?: number) {
  }
}
