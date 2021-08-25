import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ApiRoutes } from 'src/app/common/consts/api-route.const';
import { FundCriteriaModel } from 'src/app/models/asset/criteria.model';

@Injectable({
	providedIn: 'root',
})
export class FundCriteriaService {
	constructor(private http: HttpClient) {}

	public add(fundId: string, criteria: FundCriteriaModel): Observable<FundCriteriaModel> {
		return this.http.post(ApiRoutes.WorkSpaceApi.FundCriterias(fundId), criteria).pipe(map((res: any) => res.result));
	}

	public edit(fundId: string, criteriaId: string, criteria: FundCriteriaModel): Observable<FundCriteriaModel> {
		return this.http.put(ApiRoutes.WorkSpaceApi.FundCriterias(fundId)+ '/' + criteriaId, criteria).pipe(map((res: any) => res.result));
	}

	public delete(fundId: string, criteriaId: string): Observable<boolean> {
		return this.http.delete(ApiRoutes.WorkSpaceApi.FundCriterias(fundId) + '/' + criteriaId).pipe(map(() => true));
	}
}
