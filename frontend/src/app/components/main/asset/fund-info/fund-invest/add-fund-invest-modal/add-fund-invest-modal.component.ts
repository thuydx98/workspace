import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvestStatus, InvestStatusList, InvestUpdateType } from 'src/app/common/consts/assets/asset.const';
import { FundInvestModel } from 'src/app/models/asset/fund.model';

@Component({
	selector: 'app-add-fund-invest-modal',
	templateUrl: './add-fund-invest-modal.component.html',
	styleUrls: ['./add-fund-invest-modal.component.scss'],
})
export class AddFundInvestModalComponent implements OnInit {
	investment: FundInvestModel;
	criteria: any[];
	statusOptions = InvestStatusList;
	InvestStatus = InvestStatus;
	InvestUpdateType = InvestUpdateType;

	form: FormGroup;

	constructor(private fb: FormBuilder) {}

	ngOnInit(): void {
		this.form = this.fb.group({
			id: [this.investment?.id],
			name: [this.investment?.name, [Validators.required]],
			status: [this.investment?.status || InvestStatus.INVESTING, [Validators.required]],
			updateType: [this.investment?.updateType || InvestUpdateType.MANUAL, [Validators.required]],
			followedAt: [this.investment?.followedAt || new Date(), [Validators.required]],

			amount: [this.investment?.amount],
			capitalPrice: [this.investment?.capitalPrice],
			marketPrice: [this.investment?.marketPrice],
			investedAt: [this.investment?.investedAt || new Date()],

			takeProfitPercent: [this.investment?.takeProfitPercent || 15],
			stopLossPercent: [this.investment?.stopLossPercent || 6],
			trailingStopLossPercent: [this.investment?.trailingStopLossPercent || 3],

			buyFeePercent: [this.investment?.buyFeePercent || 0.127],
			sellFeePercent: [this.investment?.sellFeePercent || 0.227],
			sellPrice: [this.investment?.sellPrice],
			completedAt: [this.investment?.completedAt || new Date()],

			revenuePercent: [this.investment?.revenuePercent],
			revenueCycle: [this.investment?.revenueCycle],

			note: [this.investment?.note || 'Lý do mua: \n-  \n\nLý do bán: \n- '],
		});
	}
}
