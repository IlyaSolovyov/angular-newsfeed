import { Injectable } from '@angular/core';
import { User } from './user';
import { Source } from './source';

@Injectable()
export class Digest {

  constructor(
    public name: string,
    public creator: string,
    public isPublic: boolean,
    public id: number,
    public sources: Source[]) {
  }
}
