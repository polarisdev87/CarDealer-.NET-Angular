import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class MakeService {

  constructor(private http: Http) { }

  getMakes() {
    return this.http.get('/api/makes')
  }

}
