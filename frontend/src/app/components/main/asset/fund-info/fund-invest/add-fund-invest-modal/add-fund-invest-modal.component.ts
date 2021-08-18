import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { InvestStatus, InvestStatusList, InvestUpdateType } from 'src/app/common/consts/assets/asset.const';

@Component({
	selector: 'app-add-fund-invest-modal',
	templateUrl: './add-fund-invest-modal.component.html',
	styleUrls: ['./add-fund-invest-modal.component.scss'],
})
export class AddFundInvestModalComponent implements OnInit {
	criteria: any[];
	statusOptions = InvestStatusList;
	InvestUpdateType = InvestUpdateType;

	form: FormGroup = this.fb.group({
		name: [null, [Validators.required]],
		status: [InvestStatus.INVESTING, [Validators.required]],
		updateType: [InvestUpdateType.MANUAL, [Validators.required]],
		at: [new Date(), [Validators.required]],

		capitalPrice: [],
		amount: [],
		buyFeePercent: [],
		sellFeePercent: [],

		revenuePercent:[],
		revenueCycle: [],

		note: [],
	});

	constructor(private fb: FormBuilder) {}

	ngOnInit(): void {}
}
