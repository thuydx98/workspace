import * as index from '.';
import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgZorroModule } from '../../commons/ng-zorro.module';

import { HomeRoutingModule } from './home.routing';

const HOME_COMPONENTS: any[] = [index.HomeComponent, index.TodoComponent, index.TodoModalComponent];

@NgModule({
	declarations: [HOME_COMPONENTS],
	imports: [CommonModule, FormsModule, HomeRoutingModule, ReactiveFormsModule, NgZorroModule],
})
export class HomeModule {}
