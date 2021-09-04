import { Component, OnInit } from '@angular/core';
import { NzModalService } from 'ng-zorro-antd/modal';
import { TaskModel } from 'src/app/models/task/task.model';
import { TaskService } from 'src/app/services/tasks/task.service';
import { TodoModalComponent } from '..';
import * as moment from 'moment';
import { DateFormat } from 'src/app/common/consts/date-format.const';

@Component({
	selector: 'app-todo',
	templateUrl: './todo.component.html',
	styleUrls: ['./todo.component.scss'],
})
export class TodoComponent implements OnInit {
	loading = true;
	selectedDate: Date = new Date();
	tasks: TaskModel[];

	constructor(private taskService: TaskService, private modal: NzModalService) {}

	ngOnInit(): void {
		this.getListTask();
	}

	onSelectDate(): void {
		this.getListTask(this.selectedDate);
	}

	onAddEditTask(task?: TaskModel): void {
		const modal = this.modal.create({
			nzTitle: task ? 'Sửa' : 'Thêm' + ' công việc',
			nzContent: TodoModalComponent,
			nzComponentParams: { task, selectedDate: this.selectedDate },
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
							const at = moment(values.form.value.at).format(DateFormat.DateFormatMMDDYYYY);
							if (task) {
								this.taskService.update(task.id, { ...task, ...values.form.value, at }).subscribe(() => {
									this.getListTask(this.selectedDate);
									modal.destroy();
								});
							} else {
								this.taskService.add({ ...values.form.value, at }).subscribe(() => {
									this.getListTask(this.selectedDate);
									modal.destroy();
								});
							}
						}),
				},
			],
		});
	}

	onSetCompleted(task: TaskModel): void {
		this.taskService.update(task.id, task).subscribe();
	}

	onSetPriority(task: TaskModel): void {
		task.isPriority = !task.isPriority;
		this.taskService.update(task.id, task).subscribe();
	}

	onDelete(taskId: string): void {
		this.tasks = this.tasks.filter((item) => item.id !== taskId);
		this.taskService.delete(taskId).subscribe();
	}

	private getListTask(at?: Date): void {
		this.loading = true;
		this.taskService.getList(at || new Date()).subscribe((res) => {
			this.tasks = res;
			this.loading = false;
		});
	}
}
