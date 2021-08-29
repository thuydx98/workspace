import { DateFormat } from './../../../../../common/consts/date-format.const';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FundInvestModel } from 'src/app/models/asset/fund.model';
import { FundInvestService } from 'src/app/services/asset/fund-invest.service';
import { PagingListModel } from 'src/app/models/app/paging-list.model';
import * as StringHelper from 'src/app/common/helpers/string.helper';
import { MomentHelper } from 'src/app/common/helpers/moment.helper';
import { NzModalService } from 'ng-zorro-antd/modal';
import { AddFundInvestModalComponent } from './add-fund-invest-modal/add-fund-invest-modal.component';
import { InvestStatusList, InvestStatus } from 'src/app/common/consts/assets/asset.const';
import { FundService } from 'src/app/services/asset/fund.service';

@Component({
	selector: 'app-fund-invest',
	templateUrl: './fund-invest.component.html',
	styleUrls: ['./fund-invest.component.scss'],
})
export class FundInvestComponent implements OnInit {
	loading: boolean;
	fundId: string;
	investments: PagingListModel<FundInvestModel>;

	totalCriteriaRange = [0, this.fundService.fund?.criterias.length];
	minCriteria: number = 0;
	statusOptions = InvestStatusList;
	InvestStatus = InvestStatus;

	get isCompletedOnly(): boolean {
		const selectedOptions = this.statusOptions.filter((i) => i.checked);
		return selectedOptions.length == 1 && selectedOptions[0].value === InvestStatus.COMPLETED;
	}

	get isSelectedCompleted(): boolean {
		return this.statusOptions.findIndex((i) => i.checked && i.value === InvestStatus.COMPLETED) > -1;
	}

	constructor(
		private route: ActivatedRoute,
		private modal: NzModalService,
		private fundService: FundService,
		private fundInvestService: FundInvestService
	) {}

	ngOnInit(): void {
		this.route.params.subscribe((params) => {
			this.fundId = params['id'];
			this.getInvestments();
		});
	}

	onChangePage = (data: any) => data.pageIndex && data.pageIndex !== this.investments?.page && this.getInvestments(data.pageIndex);

	getInvestments(page: number = 1) {
		this.loading = true;
		const statuses = this.statusOptions.filter((item) => item.checked).map((item) => item.value);
		this.fundInvestService.getPagingList(this.fundId, page, 10, this.minCriteria, statuses).subscribe((res: PagingListModel<FundInvestModel>) => {
			this.investments = res;
			this.loading = false;
		});
	}

	onAddEditInvestment(investment: FundInvestModel = null): void {
		const modal = this.modal.create({
			nzTitle: investment ? 'Sửa' : 'Thêm' + ' lịch sử đầu tư',
			nzWidth: 1400,
			nzStyle: { top: '20px' },
			nzContent: AddFundInvestModalComponent,
			nzComponentParams: { investment, fundId: this.fundId, criterias: this.fundService.fund?.criterias },
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
						new Promise(() => {
							if (investment) {
								this.fundInvestService.update(this.fundId, investment.id, values.form.value).subscribe(() => {
									this.getInvestments();
									this.fundService.get(this.fundId).subscribe();
									modal.destroy();
								});
							} else {
								this.fundInvestService.add(this.fundId, values.form.value).subscribe(() => {
									this.getInvestments();
									this.fundService.get(this.fundId).subscribe();
									modal.destroy();
								});
							}
						}),
				},
			],
		});
	}

	onDeleteInvestment(investmentId: string): void {
		this.fundInvestService.delete(this.fundId, investmentId).subscribe(() => this.getInvestments());
	}

	formatDateTime = (dateInput: any, format: string = DateFormat.DateTimeFormat): string => MomentHelper.formatDateTime(dateInput, format);

	formatMoney = (moneyInput: number | string): string => StringHelper.formatMoney(moneyInput);

	getTrailingStopPrice = (investment: FundInvestModel): number => investment.highestPrice * (1 - investment.trailingStopLossPercent / 100);
}
