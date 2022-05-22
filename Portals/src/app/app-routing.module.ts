import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './component/home/home.component';
import { AppComponent } from './app.component';
import { FullLayoutComponent } from './layout/full-layout/full-layout.component';

const routes: Routes = [
  { path: '',   redirectTo: '/home', pathMatch: 'full' },
  {
    path: '', component: FullLayoutComponent, data: { title: 'Home' },

  children: [
    {
      path: 'home',
      loadChildren: () => import('./component/home/home.module').then(m => m.HomeModule)
    },
    {
      path: 'find',
      loadChildren: () => import('./component/find/find.module').then(m => m.FindModule)
    },
    {
      path: 'inform',
      loadChildren: () => import('./component/inform/inform.module').then(m => m.InformModule)
    },
  ]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }