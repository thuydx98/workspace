import { Component, OnInit } from '@angular/core';
import { FlatTreeControl } from '@angular/cdk/tree';
import { PostModel } from 'src/app/models/post/post.model';
import { NzTreeFlattener, NzTreeFlatDataSource } from 'ng-zorro-antd/tree-view';
import { SelectionModel } from '@angular/cdk/collections';
import { PostService } from 'src/app/services/post/post.service';
import { NzModalService } from 'ng-zorro-antd/modal';
import { SingleInputModalComponent } from 'src/app/components/commons/single-input-modal/single-input-modal.component';

/** Flat node with expandable and level information */
interface FlatNode {
	id: string;
	expandable: boolean;
	name: string;
	level: number;
	disabled: boolean;
}

@Component({
	selector: 'app-wiki-tree',
	templateUrl: './wiki-tree.component.html',
	styleUrls: ['./wiki-tree.component.scss'],
})
export class WikiTreeComponent implements OnInit {
	private transformer = (node: PostModel, level: number) => ({
		id: node.id,
		expandable: node.children?.length > 0,
		name: node.title,
		level,
		disabled: false,
	});

	private treeFlattener = new NzTreeFlattener(
		this.transformer,
		(node) => node.level,
		(node) => node.expandable,
		(node) => node.children
	);

	selectListSelection = new SelectionModel<FlatNode>();

	treeControl = new FlatTreeControl<FlatNode>(
		(node) => node.level,
		(node) => node.expandable
	);

	dataSource = new NzTreeFlatDataSource(this.treeControl, this.treeFlattener);

	constructor(private postService: PostService, private modal: NzModalService) {}

	ngOnInit(): void {
		this.postService.getList().subscribe((res: PostModel[]) => {
			this.dataSource.setData(res);
		});
	}

	hasChild = (_: number, node: FlatNode) => node.expandable;

	ngAfterViewInit(): void {
		setTimeout(() => {
			this.treeControl.expand(this.treeControl.dataNodes.find((n) => n.id === 'a87b149b-ca7b-46e3-83d5-c87c91f522f4') || null!);
		}, 300);
	}

	onAddPost(parentId: string = null): void {
		const modal = this.modal.create({
			nzTitle: 'Thêm tài liệu mới',
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
							post.parentId = parentId;
							this.postService.add(post).subscribe((res) => {
								modal.destroy();
							});
						}),
				},
			],
		});
	}

	onSelectNode(node: FlatNode): void {
		if (this.postService.selectedPost?.id !== node.id) {
			this.postService.get(node.id).subscribe();
		}
	}
}
