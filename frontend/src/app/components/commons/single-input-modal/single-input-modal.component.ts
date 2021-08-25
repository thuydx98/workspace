import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
	selector: 'app-single-input-modal',
	templateUrl: './single-input-modal.component.html',
	styleUrls: ['./single-input-modal.component.scss'],
})
export class SingleInputModalComponent implements OnInit {
	value: any;
	form: FormGroup;

	constructor(private fb: FormBuilder) {}

	ngOnInit(): void {
		this.form = this.fb.group({
			value: [this.value, [Validators.required]],
		});
	}
}
