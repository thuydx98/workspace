import * as index from '.';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
    {
      path: '',
      component: index.WikiComponent,
    },
    {
      path: ':id',
      component: index.WikiComponent,
    },
    {
      path: ':id/edit',
      component: index.WikiEditorComponent,
    },
];


@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WikiRoutingModule { }