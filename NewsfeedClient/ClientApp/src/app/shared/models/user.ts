import { Injectable } from '@angular/core';

@Injectable()
export class User {

  constructor(
    public username: string,
    public digests: object[],
    public friends: object[],
    public id?: number) {
  }
}
