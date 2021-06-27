import { environment } from './../../../environments/environment';

const wsApiUrl = environment.workspaceApiUrl + '/api/';

export const ApiRoutes = {
    WorkSpaceApi: {
        Assets: wsApiUrl + 'assets/'
    }
};
