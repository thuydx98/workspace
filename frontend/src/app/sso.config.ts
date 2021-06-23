import { AuthConfig } from 'angular-oauth2-oidc';

export const authCodeFlowConfig: AuthConfig = {
  issuer: 'https://localhost:5001',
  redirectUri: window.location.origin,
  clientId: 'james.workspace',
  dummyClientSecret: 'frEFKPmO9VUcUC0',
  responseType: 'code',
  scope: 'openid profile user.information workspace.features',
  showDebugInformation: true,
};
