import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';  
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzMenuModule } from 'ng-zorro-antd/menu';
import { NZ_ICONS, NzIconModule } from 'ng-zorro-antd/icon';
import { NzAvatarModule } from 'ng-zorro-antd/avatar';
import { LayoutComponent } from './layout.component';

import {
  MenuFoldOutline,
  MenuUnfoldOutline,
  FormOutline,
  DashboardOutline,
} from '@ant-design/icons-angular/icons';
import { NgZorroModule } from '../commons/ng-zorro.module';

const ANT_ICON_COMPONENTS = [
  MenuFoldOutline,
  MenuUnfoldOutline,
  DashboardOutline,
  FormOutline,
];

const LAYOUT_COMPONENTS = [LayoutComponent];

@NgModule({
  declarations: [LAYOUT_COMPONENTS],
  imports: [CommonModule, RouterModule, NgZorroModule],
  providers: [{ provide: NZ_ICONS, useValue: ANT_ICON_COMPONENTS }],
  exports: [LayoutComponent],
})
export class LayoutModule {}
