import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RouterService } from 'src/app/services/router.service';
import { FundService } from 'src/app/services/asset/fund.service';
import { FundModel } from 'src/app/models/asset/fund.model';
import { WsRoutes } from 'src/app/common/consts/route.const';
import * as StringHelper from 'src/app/common/helpers/string.helper';
import { ASSET_HISTORY_TYPE } from 'src/app/common/consts/assets/asset.const';
import { NzModalService } from 'ng-zorro-antd/modal';
import { AssetHistoryModalComponent } from '../asset-history-modal/asset-history-modal.component';
import { AssetOverviewModel } from 'src/app/models/asset/asset.model';
import { AssetService } from 'src/app/services/asset/asset.service';
import { FundHistoryService } from 'src/app/services/asset/fund-history.service';

@Component({
	selector: 'app-fund-info',
	templateUrl: './fund-info.component.html',
	styleUrls: ['./fund-info.component.scss'],
})
export class FundInfoComponent implements OnInit {
	overview: AssetOverviewModel;
	fundId: string;
	ASSET_HISTORY_TYPE = ASSET_HISTORY_TYPE;

	constructor(
		private route: ActivatedRoute,
		private routerService: RouterService,
		private modal: NzModalService,
		public fundService: FundService,
		private assetService: AssetService,
		private fundHistoryService: FundHistoryService
	) {}

	ngOnInit(): void {
		this.route.params.subscribe((params) => {
			if (params) {
				this.fundId = params['id'];
				this.getFund();
				this.getOverview();
			} else {
				this.routerService.notFound();
			}
		});
	}

	onBack(): void {
		this.routerService.navigate(WsRoutes.Assets);
	}

	onAddHistory(type: string) {
		let title;
		switch (type) {
			case ASSET_HISTORY_TYPE.FUND_RECHARGE:
				title = 'Nạp tiền từ tài khoản vào quỹ ' + this.fundService.fund.name;
				break;
			case ASSET_HISTORY_TYPE.FUND_WITHDRAW:
				title = 'Rút tiền từ quỹ ' + this.fundService.fund.name + ' về tài khoản';
				break;
		}

		const modal = this.modal.create({
			nzTitle: title,
			nzContent: AssetHistoryModalComponent,
			nzComponentParams: { fund: this.fundService.fund, type, balance: this.overview?.balance || 0 },
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
							this.fundHistoryService.add(this.fundService.fund.id, { ...values.form.value, type }).subscribe(() => {
								this.getOverview();
								this.getFund();
								this.getFundHistories();
								modal.destroy();
							});
						}),
				},
			],
		});
	}

	private getOverview(): void {
		this.assetService.getOverview().subscribe((res: AssetOverviewModel) => {
			this.overview = res;
		});
	}

	private getFund = () => this.fundService.get(this.fundId).subscribe();

	private getFundHistories = () => this.fundHistoryService.getPagingList(this.fundId).subscribe();

	formatMoney = (moneyInput: number | string): string => StringHelper.formatMoney(moneyInput);
}
