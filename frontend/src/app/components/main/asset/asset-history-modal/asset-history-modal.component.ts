import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ASSET_HISTORY_TYPE } from 'src/app/common/consts/assets/asset.const';
import { FundModel } from 'src/app/models/asset/fund.model';
import * as StringHelper from 'src/app/common/helpers/string.helper';

@Component({
	selector: 'app-asset-history-modal',
	templateUrl: './asset-history-modal.component.html',
})
export class AssetHistoryModalComponent implements OnInit {
	type: string;
	balance: number;
	fund: FundModel;

	StringHelper = StringHelper;
	formatterVND = (value: number) => `${StringHelper.formatMoney(value)} đ`;
	parserVND = (value: string) => value.match(/\d+/g).join('');

	form: FormGroup = this.fb.group({
		amount: [null, [Validators.required, Validators.min(1)]],
		at: [new Date(), [Validators.required]],
		note: [],
	});

	constructor(private fb: FormBuilder) {}

	ngOnInit(): void {}

	get maxAmount(): number {
		if (this.type === ASSET_HISTORY_TYPE.ASSET_SPEND) {
			return this.balance || 0;
		}

		if (this.type === ASSET_HISTORY_TYPE.FUND_RECHARGE) {
			return this.balance || 0;
		}

		if (this.type === ASSET_HISTORY_TYPE.FUND_WITHDRAW) {
			return this.fund?.balance || 0;
		}

		return undefined;
	}

	get withdrawableBalance(): number {
		if (this.type !== ASSET_HISTORY_TYPE.ASSET_SPEND && this.type !== ASSET_HISTORY_TYPE.FUND_RECHARGE) {
			return -1;
		}

		return this.balance;
	}
}
