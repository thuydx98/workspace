import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FundInvestModel } from 'src/app/models/asset/fund.model';
import { FundInvestService } from 'src/app/services/asset/fund-invest.service';
import { PagingListModel } from 'src/app/models/app/paging-list.model';
import * as StringHelper from 'src/app/common/helpers/string.helper';
import { MomentHelper } from 'src/app/common/helpers/moment.helper';
import { NzModalService } from 'ng-zorro-antd/modal';
import { AddFundInvestModalComponent } from './add-fund-invest-modal/add-fund-invest-modal.component';
import { InvestStatusList } from 'src/app/common/consts/assets/asset.const';

@Component({
	selector: 'app-fund-invest',
	templateUrl: './fund-invest.component.html',
	styleUrls: ['./fund-invest.component.scss'],
})
export class FundInvestComponent implements OnInit {
	fundId: string;
	investments: PagingListModel<FundInvestModel>;

	totalCriteriaRange = [0, 0];
	minCriteria: number = 0;
	statusOptions = InvestStatusList;

	constructor(private route: ActivatedRoute, private modal: NzModalService, private fundInvestService: FundInvestService) {}

	ngOnInit(): void {
		this.route.params.subscribe((params) => {
			this.fundId = params['id'];
			this.getInvestments();
		});
	}

	onChangePage = (data: any) => data.pageIndex && data.pageIndex !== this.investments?.page && this.getInvestments(data.pageIndex);

	getInvestments(page: number = 1) {
		const statuses = this.statusOptions.filter((item) => item.checked).map((item) => item.value);
		this.fundInvestService.getPagingList(this.fundId, page, 10, this.minCriteria, statuses).subscribe((res: PagingListModel<FundInvestModel>) => {
			this.investments = res;
		});
	}

	onAddInvestment(): void {
		const modal = this.modal.create({
			nzTitle: 'Tạo mới quỹ cá nhân',
			nzContent: AddFundInvestModalComponent,
			// nzViewContainerRef: this.viewContainerRef,
			nzFooter: [
				{
					label: 'Cancel',
					onClick: () => modal.destroy(),
				},
				{
					label: 'OK',
					type: 'primary',
					disabled: (values) => values.form.invalid,
					onClick: (values) =>
						new Promise(() =>
							this.fundInvestService.add(this.fundId, values.form.value).subscribe(() => {
								this.getInvestments();
								modal.destroy();
							})
						),
				},
			],
		});
	}

	formatDateTime = (dateInput: any): string => MomentHelper.formatDateTime(dateInput);

	formatMoney = (moneyInput: number): string => StringHelper.formatMoney(moneyInput);
}
