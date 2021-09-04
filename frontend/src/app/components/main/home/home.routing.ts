import * as fromHome from '.';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const errorRoutes: Routes = [
    {
      path: '',
      redirectTo: 'home'
    },
    {
      path: 'home',
      component: fromHome.HomeComponent,
    },
];


@NgModule({
  imports: [RouterModule.forChild(errorRoutes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }