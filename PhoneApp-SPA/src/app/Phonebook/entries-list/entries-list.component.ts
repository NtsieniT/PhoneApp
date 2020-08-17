import { Component, OnInit } from '@angular/core';
import { EntriesService } from '../shared/entries.service';
import { Entry } from '../shared/entries.model';
import { AlertifyService } from '../shared/alertify.service';

@Component({
  selector: 'app-entries-list',
  templateUrl: './entries-list.component.html',
  styleUrls: ['./entries-list.component.css']
})
export class EntriesListComponent implements OnInit {

  entriesList: Entry[];

  constructor(public entriesService: EntriesService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.getEntries();
  }

  getEntries(): void{
    this.entriesService.getEntries().subscribe((entries: Entry[]) => {
      this.entriesList = entries;
    },
    error => {
      this.alertify.error(error);
    }
    );
  }

  onDelete(id: number){
    if (confirm('Are you sure to delete record?') === true){
      this.entriesService.deleteEntry(id).subscribe(x =>{
        this.alertify.success('Record deleted successfully');


      },
      error => this.alertify.error(error));
    }
    setTimeout(() => { console.log(); }, 1000);
    window.location.reload();
  }

  showForEdit(entry: Entry){
    this.entriesService.selectedEntry = entry;

  }

}
