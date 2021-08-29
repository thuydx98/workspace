import { environment } from './../environments/environment';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NZ_I18N } from 'ng-zorro-antd/i18n';
import { en_US } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { OAuthModule } from 'angular-oauth2-oidc';
import { LayoutModule } from './components/layout/layout.module';
import { MainComponent } from './components/main/main.component';
import { AppRoutes } from './app.routing';
import { ErrorInterceptor } from './intercepters/error.interceptor';

registerLocaleData(en);

@NgModule({
	declarations: [AppComponent, MainComponent],
	imports: [
		BrowserModule,
		BrowserAnimationsModule,
		HttpClientModule,
		RouterModule.forRoot(AppRoutes, { useHash: true }),
		OAuthModule.forRoot({
			resourceServer: {
				allowedUrls: [environment.workspaceApiUrl],
				sendAccessToken: true,
			},
		}),
		LayoutModule,
	],
	providers: [
		{ provide: NZ_I18N, useValue: en_US },
		{ provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
	],
	bootstrap: [AppComponent],
})
export class AppModule {}
