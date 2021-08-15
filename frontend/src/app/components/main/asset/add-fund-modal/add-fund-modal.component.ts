import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
	selector: 'app-add-fund-modal',
	templateUrl: './add-fund-modal.component.html',
	styleUrls: ['./add-fund-modal.component.scss'],
})
export class AddFundModalComponent implements OnInit {
	form: FormGroup = this.fb.group({
		name: [null, [Validators.required]],
		type: [],
	});

	constructor(private fb: FormBuilder) {}

	ngOnInit(): void {}
}
