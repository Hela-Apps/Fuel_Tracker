import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HomeComponent } from './component/home/home.component';
import { AppRoutingModule } from './app-routing.module';
import { FindComponent } from './component/find/find.component';
import { FullLayoutComponent } from './layout/full-layout/full-layout.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    FindComponent,
    FullLayoutComponent
  ],
  imports: [
    BrowserModule,

    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
