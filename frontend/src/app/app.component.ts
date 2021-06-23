import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { authCodeFlowConfig } from './sso.config';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'james-workspace';

  constructor(private oauthService: OAuthService) {
    this.configureSSO();
  }

  configureSSO() {
    this.oauthService.configure(authCodeFlowConfig);
    this.oauthService.loadDiscoveryDocumentAndLogin();
  }

  logout() {
    this.oauthService.revokeTokenAndLogout();
  }

  get token() {
    let claims: any = this.oauthService.getIdentityClaims();
    return claims ? JSON.stringify(claims) : null;
  }
}
