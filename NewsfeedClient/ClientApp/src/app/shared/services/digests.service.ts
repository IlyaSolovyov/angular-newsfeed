import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Digest } from '../models/digest';

@Injectable()
export class DigestsService {

  constructor(private http: HttpClient) { }

  getDigestData(digestId: number) {
    return this.http.get<Digest>('/api//digests/' + digestId);
  }

  createDigest(digestName: string, creatorId: string) {
    const formData = new FormData();
    formData.append('name', digestName);
    formData.append('creatorId', creatorId);

    const headers = new HttpHeaders({ 'enctype': 'multipart/form-data' });

    return this.http.post('/api/digests', formData, { headers: headers });
  }

  removeDigest(digestId: number) {
    return this.http.delete('/api/digests/' + digestId);
  }

  renameDigest(digestId: number, name: string) {
    const formData = new FormData();
    formData.append('name', name);
    const headers = new HttpHeaders({ 'enctype': 'multipart/form-data' });

    return this.http.put('/api/digests/' + digestId, formData, { headers: headers });
  }

  addSourceToDigest(digestId: number, name: string, service: string, url: string) {
    const formData = new FormData();
    formData.append('name', name);
    formData.append('service', service);
    formData.append('url', url);
    const headers = new HttpHeaders({ 'enctype': 'multipart/form-data' });

    return this.http.post('/api/digests/' + digestId + '/sources', formData, { headers: headers });
  }

  removeSourceFromDigest(digestId: number, sourceId: number) {
    return this.http.delete('/api/digests/' + digestId + '/sources/' + sourceId);
  }
}
