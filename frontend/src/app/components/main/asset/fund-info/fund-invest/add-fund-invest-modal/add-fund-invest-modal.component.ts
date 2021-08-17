import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
	selector: 'app-add-fund-invest-modal',
	templateUrl: './add-fund-invest-modal.component.html',
	styleUrls: ['./add-fund-invest-modal.component.scss'],
})
export class AddFundInvestModalComponent implements OnInit {

	criteria: any[];

	form: FormGroup = this.fb.group({
		name: [null, [Validators.required]],
		type: [],
	});

	constructor(private fb: FormBuilder) {}

	ngOnInit(): void {}
}
