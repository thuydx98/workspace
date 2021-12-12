import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalService } from 'ng-zorro-antd/modal';
import { InvestStatus, InvestStatusList, InvestUpdateType } from 'src/app/common/consts/assets/asset.const';
import { SingleInputModalComponent } from 'src/app/components/commons/single-input-modal/single-input-modal.component';
import { FundCriteriaModel } from 'src/app/models/asset/criteria.model';
import { FundInvestModel } from 'src/app/models/asset/fund.model';
import { FundCriteriaService } from 'src/app/services/asset/fund-criteria.service';

@Component({
	selector: 'app-add-fund-invest-modal',
	templateUrl: './add-fund-invest-modal.component.html',
	styleUrls: ['./add-fund-invest-modal.component.scss'],
})
export class AddFundInvestModalComponent implements OnInit {
	fundId: string;
	criterias: FundCriteriaModel[] = [];
	investment: FundInvestModel;
	statusOptions = InvestStatusList;
	InvestStatus = InvestStatus;
	InvestUpdateType = InvestUpdateType;

	form: FormGroup;

	constructor(private fb: FormBuilder, private modal: NzModalService, private fundCriteriaService: FundCriteriaService) {}

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

			buyFeePercent: [this.investment?.buyFeePercent || 0.03],
			sellFeePercent: [this.investment?.sellFeePercent || 0.13],
			sellPrice: [this.investment?.sellPrice],
			completedAt: [this.investment?.completedAt || new Date()],

			revenuePercent: [this.investment?.revenuePercent],
			revenueCycle: [this.investment?.revenueCycle],

			note: [this.investment?.note || 'Lý do mua: \n-  \n\nLý do bán: \n- '],
			criterias: [this.investment?.criterias || []],
		});

		this.criterias.forEach((item) => {
			item.checked = this.form.value.criterias?.findIndex((criteriaId: string) => criteriaId === item.id) > -1;
		});
	}

	onAddEditCriteria(criteria: FundCriteriaModel = null): void {
		const modal = this.modal.create({
			nzTitle: criteria ? 'Tên tiêu chí mới' : 'Thêm tiêu chí mới',
			nzContent: SingleInputModalComponent,
			nzComponentParams: { value: criteria?.name },
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
							criteria ??= new FundCriteriaModel();
							criteria.name = values.form.value.value;

							if (criteria.id) {
								this.fundCriteriaService.edit(this.fundId, criteria.id, criteria).subscribe(() => {
									this.criterias = this.criterias.map((item: FundCriteriaModel) =>
										item.id === criteria.id ? criteria : item
									);
									modal.destroy();
								});
							} else {
								this.fundCriteriaService.add(this.fundId, criteria).subscribe((res: FundCriteriaModel) => {
									this.criterias.push(res);
									modal.destroy();
								});
							}
						}),
				},
			],
		});
	}

	onDeleteCriteria(criteriaId: string): void {
		this.fundCriteriaService.delete(this.fundId, criteriaId).subscribe(() => {
			this.criterias = this.criterias.filter((item: FundCriteriaModel) => item.id !== criteriaId);
			this.form.value.criterias = this.form.value.criterias.filter((item: string) => item !== criteriaId);
		});
	}

	onSelectCriteria(): void {
		this.form.value.criterias = this.criterias.filter((item) => item.checked).map((item) => item.id);
	}
}
