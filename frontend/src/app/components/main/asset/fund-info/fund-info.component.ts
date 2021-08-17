import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RouterService } from 'src/app/services/router.service';
import { FundService } from 'src/app/services/asset/fund.service';
import { FundModel } from 'src/app/models/asset/fund.model';
import { WsRoutes } from 'src/app/common/consts/route.const';
import * as StringHelper from 'src/app/common/helpers/string.helper';

@Component({
	selector: 'app-fund-info',
	templateUrl: './fund-info.component.html',
	styleUrls: ['./fund-info.component.scss'],
})
export class FundInfoComponent implements OnInit {
	private fundId: string;
	public fund: FundModel;

	constructor(private route: ActivatedRoute, private routerService: RouterService, private fundService: FundService) {}

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
		this.fundService.get(this.fundId).subscribe((fund: FundModel) => {
			this.fund = fund;
		});
	}

	public onBack(): void {
		this.routerService.navigate(WsRoutes.Assets);
	}

	formatMoney = (moneyInput: number): string => StringHelper.formatMoney(moneyInput);
}
