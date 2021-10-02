import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { OAuthService } from 'angular-oauth2-oidc';
import { DeviceTypes } from 'src/app/common/consts/screen.const';

@Component({
	selector: 'app-layout',
	templateUrl: './layout.component.html',
	styleUrls: ['./layout.component.scss'],
})
export class LayoutComponent implements OnInit {
	isCollapsed = true;
	isInlineMenu = window.innerWidth <= DeviceTypes.Mobile;

	constructor(private oauthService: OAuthService, private router: Router) {
		this.router.events.subscribe(() => {
			this.isCollapsed = true;
		});
	}

	ngOnInit(): void {}

	logout(): void {
		this.oauthService.revokeTokenAndLogout();
	}
}
