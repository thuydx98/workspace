import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import {
  AddFundHistoryModel,
  FundModel,
} from 'src/app/models/asset/fund.model';
import { ApiRoutes } from 'src/app/common/consts/api-route.const';
import { FundHistoryType } from 'src/app/common/enums/fund-history-type.enum';

@Injectable({
  providedIn: 'root',
})
export class FundHistoryService {
  constructor(private http: HttpClient) {}

  public getPagingList(
    fundId: string,
    page: number = 1,
    size: number = 10
  ): Observable<FundModel[]> {
    return this.http
      .get(
        ApiRoutes.WorkSpaceApi.FundHistories.replace('{fundId}', fundId) +
          `?page=${page}&size=${size}`
      )
      .pipe(map((res: any) => res.result));
  }

  public add(
    fundId: string,
    fundHistory: AddFundHistoryModel
  ): Observable<FundModel> {
    return this.http
      .post(
        ApiRoutes.WorkSpaceApi.FundHistories.replace('{fundId}', fundId),
        fundHistory
      )
      .pipe(map((res: any) => res.result));
  }
}
