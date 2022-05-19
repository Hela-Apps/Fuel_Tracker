import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { InformRoutingModule } from './inform-routing.module';
import { InformComponent } from './inform.component';


@NgModule({
  declarations: [
    InformComponent
  ],
  imports: [
    CommonModule,
    InformRoutingModule
  ]
})
export class InformModule { }
