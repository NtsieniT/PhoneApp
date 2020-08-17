import { Component, OnInit } from '@angular/core';
import { EntriesService } from '../shared/entries.service';
import { NgForm } from '@angular/forms';
import { AlertifyService } from '../shared/alertify.service';

@Component({
  selector: 'app-entries',
  templateUrl: './entries.component.html',
  styleUrls: ['./entries.component.css']
})
export class EntriesComponent implements OnInit {

  model: any = {};
  constructor(private entriesService: EntriesService, private alertify: AlertifyService) { }

  // tslint:disable-next-line:typedef
  ngOnInit() {
    this.resetFrom(this.model);
  }

  // tslint:disable-next-line:typedef
  resetFrom(form?: NgForm){

    this.model = {
      Name: null,
      PhoneNumber: null
    };

  }


  onSubmit(): void{
    this.entriesService.AddEntry(this.model).subscribe(entry => {
      this.alertify.success('Entry added successfully');
      this.resetFrom(this.model);
    },
    error => {
      this.alertify.error(error);
    });

    setTimeout(() => { console.log(); }, 5000);
    window.location.reload();

  }


}
