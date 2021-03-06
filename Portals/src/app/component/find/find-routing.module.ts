import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FindComponent } from './find.component';

const routes: Routes = [
  {
    path: '',
    component: FindComponent,
    data: {
        title: 'find'
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FindRoutingModule { }
