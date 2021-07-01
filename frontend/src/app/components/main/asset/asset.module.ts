import * as fromAsset from '.';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { NgZorroModule } from '../../commons/ng-zorro.module';
import { AssetRoutingModule } from './asset.routing';
import { ReactiveFormsModule } from '@angular/forms';

const COMPONENTS: any[] = [
  fromAsset.AssetComponent,
  fromAsset.AddIncomeModalComponent,
];

@NgModule({
  declarations: [COMPONENTS],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AssetRoutingModule,
    NgZorroModule,
  ],
})
export class AssetModule {}
