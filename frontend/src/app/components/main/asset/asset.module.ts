import * as fromAsset from '.';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';

import { NgZorroModule } from '../../commons/ng-zorro.module';
import { AssetRoutingModule } from './asset.routing';
import { ReactiveFormsModule } from '@angular/forms';
import {FormsModule } from '@angular/forms';
import { CommonComponentModule } from '../../commons/common.component.module';

const COMPONENTS: any[] = [
  fromAsset.AssetComponent,
  fromAsset.AssetHistoryModalComponent,
  fromAsset.FundInfoComponent,
  fromAsset.AddFundModalComponent,
  fromAsset.FundHistoryComponent,
  fromAsset.FundInvestComponent,
  fromAsset.AddFundInvestModalComponent,
];

@NgModule({
  declarations: [COMPONENTS],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    AssetRoutingModule,
    NgZorroModule,
    CommonComponentModule,
  ],
})
export class AssetModule {}
