export class PostModel {
	public id: string;
	public title: string;
	public avatarUrl: string;
	public content: string;
	public tags?: string[] = [];
	public parentId?: string;
	public type: string;
	public children: PostModel[];
	public updatedAt: Date;
}
