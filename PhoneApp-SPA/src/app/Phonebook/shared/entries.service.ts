import { Injectable } from '@angular/core';
import { Entry } from './entries.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class EntriesService {

  selectedEntry: Entry;
  entriesList: Entry[];

  baseUrl = 'http://localhost:5000/api/Entries/';

  constructor(private http: HttpClient) { }

  AddEntry(model: any): any{
    return this.http.post(this.baseUrl + 'AddEntry', model);
  }

  getEntries(): Observable<Entry[]>{
    return this.http.get<Entry[]>(this.baseUrl + 'All');
  }

  getEntry(id): Observable<Entry[]>{
    return this.http.get<Entry[]>(this.baseUrl + id);
  }

  updateEntry(id: number, entry: Entry){
    return this.http.put(this.baseUrl + id, entry);
  }


  deleteEntry(id: number){
    return this.http.delete(this.baseUrl + id);
  }


}
