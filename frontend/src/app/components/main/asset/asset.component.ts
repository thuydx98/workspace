import { Component, OnInit } from '@angular/core';
import { FundHistoryType } from 'src/app/common/enums/fund-history-type.enum';
import { PagingListModel } from 'src/app/models/app/paging-list.model';
import { AssetModel } from 'src/app/models/asset/asset.model';
import { FundModel } from 'src/app/models/asset/fund.model';
import { AssetService } from 'src/app/services/asset/asset.service';
import { FundHistoryService } from 'src/app/services/asset/fund-history.service';
import { FundService } from 'src/app/services/asset/fund.service';
import { RouterService } from 'src/app/services/router.service';

@Component({
	selector: 'app-asset',
	templateUrl: './asset.component.html',
	styleUrls: ['./asset.component.scss'],
})
export class AssetComponent implements OnInit {
	public FundHistoryType = FundHistoryType;
	public addIncomeModalVisible = false;
	public assetHistories: PagingListModel<AssetModel>;
	public funds: FundModel[];

	constructor(
		private assetService: AssetService,
		private fundService: FundService,
		private routerService: RouterService
	) { }

	getPercent(totalMoney: number): number {
		const total = this.funds.map((i) => i.total).reduce((a, b) => a + b, 0);
		if (total === 0) {
			return 0;
		}

		return (totalMoney / total) * 100;
	}

	ngOnInit(): void {
		this.assetService.getPagingList().subscribe((res: PagingListModel<AssetModel>) => {
			this.assetHistories = res;
		});

		this.fundService.getList().subscribe((res: FundModel[]) => {
			this.funds = res;
		});
	}

	updateAssetHistories(asset: AssetModel) {
		this.addIncomeModalVisible = false;
		if (!asset) {
			return;
		}

		this.assetHistories.items.unshift(asset);
	}

	onChangePage(data: any) {
		const { pageIndex } = data;
		this.assetService.getPagingList(pageIndex).subscribe((res: PagingListModel<AssetModel>) => {
			this.assetHistories = res;
		});
	}

	onCreateFund(): void {
		let name = prompt('Fund name:');
		if (name) {
			this.fundService.add(name).subscribe((res: FundModel) => {
				this.funds.push(res);
			});
		}
	}

	redirectToFund(fundId: string) {
		this.routerService.fundInfo(fundId);
	}
}
