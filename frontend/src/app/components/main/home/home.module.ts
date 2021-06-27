import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { NgZorroModule } from '../../commons/ng-zorro.module';
import { AddIncomeModalComponent } from './add-income-modal/add-income-modal.component';

import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home.routing';

const HOME_COMPONENTS: any[] = [HomeComponent, AddIncomeModalComponent];

@NgModule({
  declarations: [HOME_COMPONENTS],
  imports: [
    CommonModule,
    HomeRoutingModule,
    NgZorroModule,
  ],
})

export class HomeModule {}
