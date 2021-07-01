import * as fromHome from '.';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgZorroModule } from '../../commons/ng-zorro.module';

import { HomeRoutingModule } from './home.routing';

const HOME_COMPONENTS: any[] = [fromHome.HomeComponent];

@NgModule({
  declarations: [HOME_COMPONENTS],
  imports: [
    CommonModule,
    HomeRoutingModule,
    NgZorroModule,
  ],
})

export class HomeModule {}
