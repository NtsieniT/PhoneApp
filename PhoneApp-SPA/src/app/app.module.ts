import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PhonebookComponent } from './Phonebook/Phonebook.component';
import { EntriesComponent } from './Phonebook/entries/entries.component';
import { EntriesListComponent } from './Phonebook/entries-list/entries-list.component';
import { EntriesService } from './Phonebook/shared/entries.service';
import { AlertifyService } from './Phonebook/shared/alertify.service';
import { ErrorInterceptorProvider } from './Phonebook/shared/error.interceptor';

@NgModule({
  declarations: [
    AppComponent,
      PhonebookComponent,
      EntriesComponent,
      EntriesListComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [
    EntriesService,
    AlertifyService,
  ErrorInterceptorProvider],
  bootstrap: [AppComponent]
})
export class AppModule { }
