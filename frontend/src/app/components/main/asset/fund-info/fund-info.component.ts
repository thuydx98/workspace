import { map } from 'rxjs/operators';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { zip } from 'rxjs';
import { RouterService } from 'src/app/services/router.service';
import { FundService } from 'src/app/services/asset/fund.service';
import { FundHistoryModel, FundModel } from 'src/app/models/asset/fund.model';
import { FundHistoryService } from 'src/app/services/asset/fund-history.service';
import { PagingListModel } from 'src/app/models/app/paging-list.model';
import { WsRoutes } from 'src/app/common/consts/route.const';

@Component({
	selector: 'app-fund-info',
	templateUrl: './fund-info.component.html',
	styleUrls: ['./fund-info.component.scss'],
})
export class FundInfoComponent implements OnInit {
	private fundId: string;
	public fund: FundModel;
	public pagingHistories: PagingListModel<FundHistoryModel>;

	constructor(
		private route: ActivatedRoute,
		private routerService: RouterService,
		private fundService: FundService,
		private funHistoryService: FundHistoryService
	) { }

	ngOnInit(): void {
		this.route.params.subscribe((params) => {
			if (params) {
				this.fundId = params['id'];
				this.initData();
			} else {
				this.routerService.notFound();
			}
		});
	}

	private initData() {
		zip(
			this.fundService.get(this.fundId),
			this.funHistoryService.getPagingList(this.fundId)
		).pipe(
			map(([fund, pagingHistories]) => {
				this.fund = fund;
				this.pagingHistories = pagingHistories;
			})
		).subscribe();
	}

	public onBack(): void {
		this.routerService.navigate(WsRoutes.Assets);
	}
}
