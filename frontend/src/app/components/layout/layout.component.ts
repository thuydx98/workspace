import { Component, OnInit } from '@angular/core';
import { OAuthService } from 'angular-oauth2-oidc';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {
  isCollapsed = false;

  constructor(private oauthService: OAuthService) { }

  ngOnInit(): void {
  }

  logout(): void {
    this.oauthService.revokeTokenAndLogout();
  }

}
