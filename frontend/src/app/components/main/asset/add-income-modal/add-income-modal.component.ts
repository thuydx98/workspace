import {
	AddAssetModal,
	AssetModel,
} from './../../../../models/asset/asset.model';
import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AssetService } from 'src/app/services/asset/asset.service';

@Component({
	selector: 'app-add-income-modal',
	templateUrl: './add-income-modal.component.html',
})
export class AddIncomeModalComponent implements OnInit {
	isOkLoading = false;
	form!: FormGroup;

	@Input() isVisible: boolean = false;
	@Output() closeModal = new EventEmitter();

	constructor(
		private fb: FormBuilder,
		private assetService: AssetService
	) {}

	ngOnInit(): void {
		this.form = this.fb.group({
			amount: [null, [Validators.required]],
			at: [new Date(), [Validators.required]],
			note: [],
		});
	}

	handleOk(asset: AddAssetModal): void {
		this.isOkLoading = true;
		this.assetService
			.addAsset(asset)
			.subscribe((res: AssetModel) => {
				this.isVisible = false;
				this.isOkLoading = false;
				this.closeModal.emit(res);
			});
	}

	handleCancel(): void {
		this.closeModal.emit();
		this.isVisible = false;
	}
}
