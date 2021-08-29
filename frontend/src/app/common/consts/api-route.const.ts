import { environment } from "src/environments/environment";

const wsApiUrl = environment.workspaceApiUrl + '/api/';

export const ApiRoutes = {
    WorkSpaceApi: {
        Assets: wsApiUrl + 'assets',
        Posts: wsApiUrl + 'posts',
        Funds: wsApiUrl + 'funds',
        FundHistories: wsApiUrl + 'funds/{fundId}/histories',
        FundInvestments: (fundId: string) => wsApiUrl + `funds/${fundId}/investments`,
        FundCriterias: (fundId: string) => wsApiUrl + `funds/${fundId}/criterias`,
    }
};
