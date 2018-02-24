import { Injectable } from '@angular/core';
import { User } from './user';

@Injectable()
export class Source {

  constructor(
    public id: number,
    public name: string,
    public url: string,
    public service: string) {
  }
}
