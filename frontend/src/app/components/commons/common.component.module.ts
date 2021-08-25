import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { NgZorroModule } from './ng-zorro.module';

import { SingleInputModalComponent } from './single-input-modal/single-input-modal.component';

@NgModule({
	declarations: [SingleInputModalComponent],
	imports: [ReactiveFormsModule, NgZorroModule],
	exports: [SingleInputModalComponent],
})
export class CommonComponentModule {}
