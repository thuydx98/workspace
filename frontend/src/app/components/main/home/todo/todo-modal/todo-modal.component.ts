import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TaskModel } from 'src/app/models/task/task.model';

@Component({
	selector: 'app-todo-modal',
	templateUrl: './todo-modal.component.html',
	styleUrls: ['./todo-modal.component.scss'],
})
export class TodoModalComponent implements OnInit {
	task: TaskModel;
	selectedDate: Date;
	form: FormGroup;

	constructor(private fb: FormBuilder) {}

	ngOnInit(): void {
		this.form = this.fb.group({
			title: [this.task?.title, [Validators.required]],
			at: [this.task?.at ? new Date(this.task?.at) : this.selectedDate || new Date(), [Validators.required]],
			content: [this.task?.content],
		});
	}
}
