import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ApiRoutes } from 'src/app/common/consts/api-route.const';
import { TaskModel } from 'src/app/models/task/task.model';
import * as moment from 'moment';
import { DateFormat } from 'src/app/common/consts/date-format.const';

@Injectable({
	providedIn: 'root',
})
export class TaskService {
	constructor(private http: HttpClient) {}

	public getList(at: Date): Observable<TaskModel[]> {
		const date = moment(at).format(DateFormat.DateFormatMMDDYYYY);
		return this.http.get(ApiRoutes.WorkSpaceApi.Tasks + '?at=' + date).pipe(map((res: any) => res.result));
	}

	public add(task: TaskModel): Observable<TaskModel> {
		return this.http.post(ApiRoutes.WorkSpaceApi.Tasks, task).pipe(map((res: any) => res.result));
	}

	public update(taskId: string, task: TaskModel): Observable<TaskModel> {
		return this.http.put(ApiRoutes.WorkSpaceApi.Tasks + '/' + taskId, task).pipe(map((res: any) => res.result));
	}

	public delete(taskId: string): Observable<void> {
		return this.http.delete(ApiRoutes.WorkSpaceApi.Tasks + '/' + taskId).pipe(map((res: any) => res.result));
	}
}
