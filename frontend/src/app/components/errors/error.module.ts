import { NgModule } from '@angular/core';
import { ErrorRoutingModule } from './error.routing';

const ERROR_COMPONENTS: any[] = [];

@NgModule({
  declarations: [ERROR_COMPONENTS],
  imports: [
    ErrorRoutingModule,
  ],
})

export class ErrorModule {}
