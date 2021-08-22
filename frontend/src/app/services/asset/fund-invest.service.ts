import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { FundInvestModel, AddFundInvestModel } from 'src/app/models/asset/fund.model';
import { ApiRoutes } from 'src/app/common/consts/api-route.const';
import { PagingListModel } from 'src/app/models/app/paging-list.model';
import { InvestStatus } from 'src/app/common/consts/assets/asset.const';

@Injectable({
	providedIn: 'root',
})
export class FundInvestService {
	constructor(private http: HttpClient) {}

	public getPagingList(
		fundId: string,
		page: number = 1,
		size: number = 10,
		minCriteria: number = 0,
		statuses: string[] = []
	): Observable<PagingListModel<FundInvestModel>> {
		return this.http
			.get(
				ApiRoutes.WorkSpaceApi.FundInvestments(fundId) +
					`?page=${page}&size=${size}&minCriteria=${minCriteria}&statuses=${statuses.join(',')}`
			)
			.pipe(map((res: any) => res.result));
	}

	public add(fundId: string, fundInvest: AddFundInvestModel): Observable<FundInvestModel> {
		return this.http.post(ApiRoutes.WorkSpaceApi.FundInvestments(fundId), fundInvest).pipe(map((res: any) => res.result));
	}

	public update(fundId: string, investmentId: string, fundInvest: AddFundInvestModel): Observable<FundInvestModel> {
		return this.http.put(ApiRoutes.WorkSpaceApi.FundInvestments(fundId) + '/' + investmentId, fundInvest).pipe(map((res: any) => res.result));
	}
}
