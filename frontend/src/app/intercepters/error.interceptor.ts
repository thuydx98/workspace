import { catchError, retry } from 'rxjs/operators';
import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpErrorResponse, HttpStatusCode } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { RouterService } from '../services/router.service';
import { OAuthService } from 'angular-oauth2-oidc';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
	constructor(private route: RouterService, private oauthService: OAuthService) {}

	intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
		return next.handle(request).pipe(
			retry(1),
			catchError((error: HttpErrorResponse) => {
				switch (error.status) {
					case HttpStatusCode.Unauthorized:
						this.oauthService.loadDiscoveryDocumentAndLogin();
						break;
					case HttpStatusCode.Forbidden:
						this.route.forbidden();
						break;
					case HttpStatusCode.NotFound:
						this.route.notFound();
						break;
					case HttpStatusCode.ServiceUnavailable:
						this.route.serviceMaintain();
						break;
					default:
						return throwError({
							code: error.status,
							message: error.error.errorMessage || error.statusText,
						});
				}

				return next.handle(request);
			})
		);
	}
}
