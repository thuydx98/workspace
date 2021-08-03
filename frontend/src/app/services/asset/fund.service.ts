import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { FundModel } from 'src/app/models/asset/fund.model';
import { ApiRoutes } from 'src/app/common/consts/api-route.const';

@Injectable({
  providedIn: 'root'
})
export class FundService {
  constructor(private http: HttpClient) { }

  public getList(): Observable<FundModel[]> {
    return this.http.get(ApiRoutes.WorkSpaceApi.Funds)
      .pipe(
        map((res: any) => res.result)
      );
  }

  public get(fundId: string): Observable<FundModel> {
    return this.http.get(ApiRoutes.WorkSpaceApi.Funds + '/' + fundId)
      .pipe(
        map((res: any) => res.result)
      );
  }

  public add(name: string): Observable<FundModel> {
    return this.http.post(ApiRoutes.WorkSpaceApi.Funds, {name})
      .pipe(
        map((res: any) => res.result)
      );
  }
}
