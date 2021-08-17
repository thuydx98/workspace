import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FundHistoryModel } from 'src/app/models/asset/fund.model';
import { FundHistoryService } from 'src/app/services/asset/fund-history.service';
import { PagingListModel } from 'src/app/models/app/paging-list.model';
import * as StringHelper from 'src/app/common/helpers/string.helper';
import { MomentHelper } from 'src/app/common/helpers/moment.helper';

@Component({
	selector: 'app-fund-history',
	templateUrl: './fund-history.component.html',
	styleUrls: ['./fund-history.component.scss'],
})
export class FundHistoryComponent implements OnInit {
	private fundId: string;
	public pagingHistories: PagingListModel<FundHistoryModel>;

	constructor(private route: ActivatedRoute, private funHistoryService: FundHistoryService) {}

	ngOnInit(): void {
		this.route.params.subscribe((params) => {
			this.fundId = params['id'];
			this.getHistories();
		});
	}
	onChangePage = (data: any) => data.pageIndex && this.getHistories(data.pageIndex);

	private getHistories(page: number = 1) {
		this.funHistoryService.getPagingList(this.fundId, page).subscribe((res: PagingListModel<FundHistoryModel>) => {
			this.pagingHistories = res;
		});
	}

	formatDateTime = (dateInput: any): string => MomentHelper.formatDateTime(dateInput);

	formatMoney = (moneyInput: number): string => StringHelper.formatMoney(moneyInput);
}
