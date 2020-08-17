import { Component, OnInit } from '@angular/core';
import {  EntriesService } from './shared/entries.service';

@Component({
  selector: 'app-Phonebook',
  templateUrl: './Phonebook.component.html',
  styleUrls: ['./Phonebook.component.css']
})
export class PhonebookComponent implements OnInit {

  constructor(public entriesService: EntriesService) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
  }

}
