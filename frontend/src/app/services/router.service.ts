import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
	providedIn: 'root',
})
export class RouterService {
	constructor(private router: Router) {}

	// ERROR
	public forbidden(): void {
		this.router.navigate(['/error/access-denied']);
	}
	public serverError(): void {
		this.router.navigate(['/error/server-error']);
	}
	public notFound(): void {
		this.router.navigate(['/error/not-found']);
	}
	public serviceMaintain(): void {
		this.router.navigate(['/error/service-maintain']);
	}

	// GENERAL
	public navigate(url: string): void {
		this.router.navigateByUrl(url);
	}

	public home(): void {
		this.router.navigate(['/']);
	}

	public fundInfo(id: string): void {
		const url = '/assets/funds/' + id;
		this.router.navigate([url]);
	}

	public wikiInfo(id: string): void {
		const url = '/wiki/' + id;
		this.router.navigate([url]);
	}

	public wikiEdit(id: string): void {
		const url = '/wiki/' + id + '/edit';
		this.router.navigate([url]);
	}

	public redirect(url: string): void {
		window.location.href = url;
	}
}
