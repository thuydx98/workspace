import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { AssetOverviewModel, AddAssetModal, AssetModel } from 'src/app/models/asset/asset.model';
import { ApiRoutes } from 'src/app/common/consts/api-route.const';
import { PagingListModel } from 'src/app/models/app/paging-list.model';

@Injectable({
	providedIn: 'root',
})
export class AssetService {
	constructor(private http: HttpClient) {}

	public getOverview(): Observable<AssetOverviewModel> {
		return this.http.get(ApiRoutes.WorkSpaceApi.Assets + '/overview').pipe(map((res: any) => res.result));
	}

	public getPagingList(page: number = 1, size: number = 10): Observable<PagingListModel<AssetModel>> {
		return this.http.get(ApiRoutes.WorkSpaceApi.Assets + `?page=${page}&size=${size}`).pipe(map((res: any) => res.result));
	}

	public addAsset(asset: AddAssetModal): Observable<AssetModel> {
		return this.http.post(ApiRoutes.WorkSpaceApi.Assets, asset).pipe(map((res: any) => res.result));
	}
}
