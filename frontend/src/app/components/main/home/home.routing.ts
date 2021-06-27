import * as fromHome from '.';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const errorRoutes: Routes = [
    {
      path: '',
      component: fromHome.HomeComponent,
    },
];


@NgModule({
  imports: [RouterModule.forChild(errorRoutes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }