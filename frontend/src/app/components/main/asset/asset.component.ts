import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { PagingListModel } from 'src/app/models/app/paging-list.model';
import { AssetModel, AssetOverviewModel } from 'src/app/models/asset/asset.model';
import { FundModel } from 'src/app/models/asset/fund.model';
import { AssetService } from 'src/app/services/asset/asset.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FundService } from 'src/app/services/asset/fund.service';
import { RouterService } from 'src/app/services/router.service';
import * as StringHelper from 'src/app/common/helpers/string.helper';
import { AddFundModalComponent } from './add-fund-modal/add-fund-modal.component';
import { ASSET_HISTORY_TYPE } from 'src/app/common/consts/assets/asset.const';
import { AssetHistoryModalComponent } from './asset-history-modal/asset-history-modal.component';
import { FundHistoryService } from 'src/app/services/asset/fund-history.service';
import { MomentHelper } from 'src/app/common/helpers/moment.helper';

@Component({
	selector: 'app-asset',
	templateUrl: './asset.component.html',
	styleUrls: ['./asset.component.scss'],
})
export class AssetComponent implements OnInit {
	ASSET_HISTORY_TYPE = ASSET_HISTORY_TYPE;

	assetHistories: PagingListModel<AssetModel>;
	funds: FundModel[];
	overview: AssetOverviewModel;

	constructor(
		private assetService: AssetService,
		private fundService: FundService,
		private fundHistoryService: FundHistoryService,
		private routerService: RouterService,
		private modal: NzModalService,
		private viewContainerRef: ViewContainerRef
	) {}

	ngOnInit(): void {
		this.getOverview();
		this.getPagingAssets();
		this.getFunds();
	}

	onAddHistory(type: string, fund?: FundModel) {
		let title;
		switch (type) {
			case ASSET_HISTORY_TYPE.ASSET_INCOME:
				title = 'Thêm thu nhập';
				break;
			case ASSET_HISTORY_TYPE.ASSET_SPEND:
				title = 'Rút tiền từ thu nhập';
				break;
			case ASSET_HISTORY_TYPE.FUND_RECHARGE:
				title = 'Nạp tiền vào quỹ ' + fund.name;
				break;
			case ASSET_HISTORY_TYPE.FUND_WITHDRAW:
				title = 'Rút tiền từ quỹ ' + fund.name;
				break;
		}

		const modal = this.modal.create({
			nzTitle: title,
			nzContent: AssetHistoryModalComponent,
			nzViewContainerRef: this.viewContainerRef,
			nzComponentParams: { fund, type, balance: this.overview?.balance || 0 },
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
							if (type === ASSET_HISTORY_TYPE.ASSET_INCOME || type === ASSET_HISTORY_TYPE.ASSET_SPEND) {
								this.assetService.addAsset({ ...values.form.value, type }).subscribe(() => {
									this.getOverview();
									this.getPagingAssets();
									modal.destroy();
								});
							}
							if (type === ASSET_HISTORY_TYPE.FUND_RECHARGE || type === ASSET_HISTORY_TYPE.FUND_WITHDRAW) {
								this.fundHistoryService.add(fund.id, { ...values.form.value, type }).subscribe(() => {
									this.getOverview();
									this.getFunds();
									modal.destroy();
								});
							}
						}),
				},
			],
		});
	}

	onAddFund(): void {
		const modal = this.modal.create({
			nzTitle: 'Tạo mới quỹ cá nhân',
			nzContent: AddFundModalComponent,
			nzViewContainerRef: this.viewContainerRef,
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
							this.fundService.add(values.form.value).subscribe(() => {
								this.getFunds();
								modal.destroy();
							})
						),
				},
			],
		});
	}

	redirectToFund(fundId: string) {
		this.routerService.fundInfo(fundId);
	}

	onDeleteFund(fund: FundModel) {
		if (fund.total > 0) {
			this.modal.error({
				nzTitle: 'Cannot delete this fund',
				nzContent: 'Total money must be equal to 0. Current is ' + StringHelper.formatMoney(fund.total) + 'đ',
			});

			return;
		}

		const modal = this.modal.confirm({
			nzTitle: `Do you want to delete <b>${fund.name}</b>?`,
			nzContent: `When deleted this fund, it can't be revert`,
			nzOkText: 'Yes',
			nzCancelText: 'No',
			nzOkDanger: true,
			nzOnOk: () =>
				new Promise(() => {
					this.fundService.delete(fund.id).subscribe(() => {
						this.funds = this.funds.filter((item) => item.id !== fund.id);
						modal.destroy();
					});
				}),
		});
	}

	onChangePage = (data: any) => data.pageIndex && this.getPagingAssets(data.pageIndex);

	formatDateTime = (dateInput: any): string =>  MomentHelper.formatDateTime(dateInput);

	formatMoney = (moneyInput: number): string =>  StringHelper.formatMoney(moneyInput);

	getPercent = (totalMoney: number): string => {
		const total = this.funds.map((i) => i.total).reduce((a, b) => a + b, 0);
		if (total === 0) {
			return '0 %';
		}

		const percent = (totalMoney / total) * 100;

		return +percent.toFixed(2) + '%';
	};


	private getOverview(): void {
		this.assetService.getOverview().subscribe((res: AssetOverviewModel) => {
			this.overview = res;
		});
	}

	private getPagingAssets(page: number = 1): void {
		this.assetService.getPagingList(page).subscribe((res: PagingListModel<AssetModel>) => {
			this.assetHistories = res;
		});
	}

	private getFunds(): void {
		this.fundService.getList().subscribe((res: FundModel[]) => {
			this.funds = res;
		});
	}
}
