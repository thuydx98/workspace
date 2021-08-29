import * as index from '.';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { CKEditorModule } from '@ckeditor/ckeditor5-angular';
import { NgZorroModule } from '../../commons/ng-zorro.module';
import { WikiRoutingModule } from './wiki.routing';

const COMPONENTS: any[] = [index.WikiComponent, index.WikiTreeComponent, index.WikiEditorComponent, index.WikiViewComponent];

@NgModule({
	declarations: [COMPONENTS],
	imports: [CommonModule, ReactiveFormsModule, NgZorroModule, CKEditorModule, WikiRoutingModule],
})
export class WikiModule {}
