import { environment } from "src/environments/environment";

const wsApiUrl = environment.workspaceApiUrl + '/api/';

export const ApiRoutes = {
    WorkSpaceApi: {
        Assets: wsApiUrl + 'assets',
        Funds: wsApiUrl + 'funds',
        FundHistories: wsApiUrl + 'funds/{fundId}/histories',
    }
};
