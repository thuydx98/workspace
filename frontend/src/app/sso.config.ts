import { AuthConfig } from 'angular-oauth2-oidc';

export const authCodeFlowConfig: AuthConfig = {
  issuer: 'https://id.azurewebsites.net',
  redirectUri: window.location.origin,
  clientId: 'james.workspace',
  dummyClientSecret: 'frEFKPmO9VUcUC0',
  responseType: 'code',
  scope: 'openid profile user.information workspace.features',
  showDebugInformation: false,
};
