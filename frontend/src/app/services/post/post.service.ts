import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ApiRoutes } from 'src/app/common/consts/api-route.const';
import { PostModel } from 'src/app/models/post/post.model';

@Injectable({
	providedIn: 'root',
})
export class PostService {
	selectedPost: PostModel;

	constructor(private http: HttpClient) {}

	public getList(): Observable<PostModel[]> {
		return this.http.get(ApiRoutes.WorkSpaceApi.Posts).pipe(map((res: any) => this.updateChildrenPost(null, res.result)));
	}

	public get(postId: string): Observable<any> {
		return this.http.get(ApiRoutes.WorkSpaceApi.Posts + '/' + postId).pipe(map((res: any) => {
			this.selectedPost = res.result;
		}));
	}

	public add(post: PostModel): Observable<PostModel> {
		return this.http.post(ApiRoutes.WorkSpaceApi.Posts, post).pipe(map((res: any) => res.result));
	}

	public update(postId: string, post: PostModel): Observable<PostModel> {
		return this.http.put(ApiRoutes.WorkSpaceApi.Posts + '/' + postId, post).pipe(map((res: any) => res.result));
	}

	public delete(postId: string): Observable<void> {
		return this.http.delete(ApiRoutes.WorkSpaceApi.Posts + '/' + postId).pipe(map((res: any) => res.result));
	}

	private updateChildrenPost(parentId: string = null, rawData: PostModel[]): PostModel[] {
		const posts = rawData.filter((item) => item.parentId === parentId);
		posts.forEach((item) => {
			item.children = this.updateChildrenPost(item.id, rawData);
		});

		return posts;
	}
}
