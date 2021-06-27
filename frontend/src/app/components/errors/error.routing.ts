import * as fromError from '.';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WsRoutes } from 'src/app/common/consts/route.const';

const errorRoutes: Routes = [
    {
      path: WsRoutes.NotFound,
      component: fromError.NotFoundComponent,
    },
];


@NgModule({
  imports: [RouterModule.forChild(errorRoutes)],
  exports: [RouterModule]
})
export class ErrorRoutingModule { }