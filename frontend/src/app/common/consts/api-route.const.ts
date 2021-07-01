import { environment } from "src/environments/environment";

const wsApiUrl = environment.workspaceApiUrl + '/api/';

export const ApiRoutes = {
    WorkSpaceApi: {
        Assets: wsApiUrl + 'assets/'
    }
};
