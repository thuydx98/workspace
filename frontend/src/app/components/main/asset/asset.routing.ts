import * as fromAsset from '.';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
      path: '',
      component: fromAsset.AssetComponent,
    },
    {
      path: 'funds/:id',
      component: fromAsset.FundInfoComponent,
    },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AssetRoutingModule { }