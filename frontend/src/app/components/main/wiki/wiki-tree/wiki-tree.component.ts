import { RouterService } from './../../../../services/router.service';
import { Component, OnInit } from '@angular/core';
import { PostModel } from 'src/app/models/post/post.model';
import { PostService } from 'src/app/services/post/post.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { SingleInputModalComponent } from 'src/app/components/commons/single-input-modal/single-input-modal.component';
import { ActivatedRoute } from '@angular/router';
import { NzFormatEmitEvent, NzTreeNode } from 'ng-zorro-antd/tree';

@Component({
	selector: 'app-wiki-tree',
	templateUrl: './wiki-tree.component.html',
	styleUrls: ['./wiki-tree.component.scss'],
})
export class WikiTreeComponent implements OnInit {
	selectedId: string;
	posts: PostModel[];

	constructor(private route: ActivatedRoute, private routerService: RouterService, private postService: PostService, private modal: NzModalService) {}

	ngOnInit(): void {
		this.postService.getList().subscribe((res: PostModel[]) => {
			this.posts = res;
		});

		this.route.params.subscribe((params) => {
			this.selectedId = params['id'];
		});
	}

	onAddPost(node: NzTreeNode = null): void {
		const modal = this.modal.create({
			nzTitle: 'Tiêu đề bài viết',
			nzContent: SingleInputModalComponent,
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
							const post = new PostModel();
							post.title = values.form.value.value;
							post.parentId = node?.key;
							this.postService.add(post).subscribe((res) => {
								modal.destroy();
								this.routerService.wikiInfo(res.id);
								this.posts = [...this.posts, res];
							});
						}),
				},
			],
		});
	}

	onEdit = (id: string) => this.routerService.wikiEdit(id);

	onOpen(id: string, currentStatus: boolean): void {
		this.posts = this.posts.map((item) => (item.id !== id ? item : { ...item, expanded: !currentStatus }));
	}

	onSelectNode(data: NzFormatEmitEvent): void {
		this.posts = this.posts.map((item) => (item.id !== data.node.key ? item : { ...item, selected: true }));
		this.routerService.wikiInfo(data.node.key);
	}

	convertPostToNode(parentId: string = null, data: PostModel[] = this.posts || []): any[] {
		const posts = data
			.filter((item) => item.parentId === parentId)
			.map((item) => {
				const children = this.convertPostToNode(item.id, data);
				const isExpand = children.findIndex((item: any) => item.selected || item.expanded) > -1;

				return {
					title: item.title,
					key: item.id,
					expanded: item.expanded === undefined ? isExpand : item.expanded,
					isLeaf: children.length === 0,
					children,
					selected: item.id === this.selectedId,
				};
			});

		return posts;
	}
}
