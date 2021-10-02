import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FundHistoryService } from 'src/app/services/asset/fund-history.service';
import * as StringHelper from 'src/app/common/helpers/string.helper';
import { MomentHelper } from 'src/app/common/helpers/moment.helper';
import { DeviceTypes } from 'src/app/common/consts/screen.const';

@Component({
	selector: 'app-fund-history',
	templateUrl: './fund-history.component.html',
	styleUrls: ['./fund-history.component.scss'],
})
export class FundHistoryComponent implements OnInit {
	fundId: string;
	isShowColumn = window.innerWidth > DeviceTypes.Mobile;

	constructor(private route: ActivatedRoute, public fundHistoryService: FundHistoryService) {}

	ngOnInit(): void {
		this.route.params.subscribe((params) => {
			this.fundId = params['id'];
			this.getHistories();
		});
	}
	onChangePage = (data: any) => data.pageIndex && data.pageIndex !== this.fundHistoryService.pagingHistories?.page && this.getHistories(data.pageIndex);

	private getHistories = (page: number = 1) => this.fundHistoryService.getPagingList(this.fundId, page).subscribe();

	formatDateTime = (dateInput: any): string => MomentHelper.formatDateTime(dateInput);

	formatMoney = (moneyInput: number): string => StringHelper.formatMoney(moneyInput);
}
