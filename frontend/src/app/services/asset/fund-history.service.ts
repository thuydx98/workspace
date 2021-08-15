import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { AddFundHistoryModel, FundHistoryModel } from 'src/app/models/asset/fund.model';
import { ApiRoutes } from 'src/app/common/consts/api-route.const';
import { PagingListModel } from 'src/app/models/app/paging-list.model';

@Injectable({
	providedIn: 'root',
})
export class FundHistoryService {
	constructor(private http: HttpClient) {}

	public getPagingList(fundId: string, page: number = 1, size: number = 10): Observable<PagingListModel<FundHistoryModel>> {
		return this.http
			.get(ApiRoutes.WorkSpaceApi.FundHistories.replace('{fundId}', fundId) + `?page=${page}&size=${size}`)
			.pipe(map((res: any) => res.result));
	}

	public add(fundId: string, fundHistory: AddFundHistoryModel): Observable<FundHistoryModel> {
		return this.http
			.post(ApiRoutes.WorkSpaceApi.FundHistories.replace('{fundId}', fundId), fundHistory)
			.pipe(map((res: any) => res.result));
	}
}
