import { Injectable } from '@angular/core';
import { Digest } from './digest';

@Injectable()
export class User {

  constructor(
    public username: string,
    public id: number,
    public avatarFilename: string,
    public email?: string,
    public digests?: Digest[],
    public friends?: object[]) {
  }
}
