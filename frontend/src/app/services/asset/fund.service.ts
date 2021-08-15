import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { AddFundModel, FundModel } from 'src/app/models/asset/fund.model';
import { ApiRoutes } from 'src/app/common/consts/api-route.const';

@Injectable({
	providedIn: 'root',
})
export class FundService {
	constructor(private http: HttpClient) {}

	public getList(): Observable<FundModel[]> {
		return this.http.get(ApiRoutes.WorkSpaceApi.Funds).pipe(map((res: any) => res.result));
	}

	public get(fundId: string): Observable<FundModel> {
		return this.http.get(ApiRoutes.WorkSpaceApi.Funds + '/' + fundId).pipe(map((res: any) => res.result));
	}

	public add(fund: AddFundModel): Observable<FundModel> {
		return this.http.post(ApiRoutes.WorkSpaceApi.Funds, fund).pipe(map((res: any) => res.result));
	}

	public delete(fundId: string): Observable<any> {
		return this.http.delete(ApiRoutes.WorkSpaceApi.Funds + '/' + fundId).pipe(map((res: any) => res.result));
	}
}
