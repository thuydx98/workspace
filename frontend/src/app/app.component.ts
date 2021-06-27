import { Component } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';
import { authCodeFlowConfig } from './common/consts/sso.const';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  constructor(private oauthService: OAuthService) {
    this.configureSSO();
  }

  configureSSO() {
    this.oauthService.configure(authCodeFlowConfig);
    this.oauthService.loadDiscoveryDocumentAndLogin();
  }

  get token() {
    return this.oauthService.getIdToken();
  }
}
