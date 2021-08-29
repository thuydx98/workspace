import { CollectionViewer, DataSource, SelectionChange } from '@angular/cdk/collections';
import { TreeControl } from '@angular/cdk/tree';
import { BehaviorSubject, merge, Observable, of } from 'rxjs';
import { delay, map, tap } from 'rxjs/operators';
import { IFlatNode } from './wiki-flat-node.interface';

function getChildren(node: IFlatNode): Observable<IFlatNode[]> {
	return of([
		{
			id: Date.now(),
			label: `Child Node (level-${node.level + 1})`,
			level: node.level + 1,
			expandable: true,
		},
		{
			id: Date.now(),
			label: `Child Node (level-${node.level + 1})`,
			level: node.level + 1,
			expandable: true,
		},
		{
			id: Date.now(),
			label: `Leaf Node (level-${node.level + 1})`,
			level: node.level + 1,
			expandable: false,
		},
	]).pipe(delay(500));
}

export class WikiDataSource implements DataSource<IFlatNode> {
	private flattenedData: BehaviorSubject<IFlatNode[]>;
	private childrenLoadedSet = new Set<IFlatNode>();

	constructor(private treeControl: TreeControl<IFlatNode>, initData: IFlatNode[]) {
		this.flattenedData = new BehaviorSubject<IFlatNode[]>(initData);
		treeControl.dataNodes = initData;
	}

	connect(collectionViewer: CollectionViewer): Observable<IFlatNode[]> {
		const changes = [
			collectionViewer.viewChange,
			this.treeControl.expansionModel.changed.pipe(tap((change) => this.handleExpansionChange(change))),
			this.flattenedData,
		];
		return merge(...changes).pipe(map(() => this.expandFlattenedNodes(this.flattenedData.getValue())));
	}

	expandFlattenedNodes(nodes: IFlatNode[]): IFlatNode[] {
		const treeControl = this.treeControl;
		const results: IFlatNode[] = [];
		const currentExpand: boolean[] = [];
		currentExpand[0] = true;

		nodes.forEach((node) => {
			let expand = true;
			for (let i = 0; i <= treeControl.getLevel(node); i++) {
				expand = expand && currentExpand[i];
			}
			if (expand) {
				results.push(node);
			}
			if (treeControl.isExpandable(node)) {
				currentExpand[treeControl.getLevel(node) + 1] = treeControl.isExpanded(node);
			}
		});
		return results;
	}

	handleExpansionChange(change: SelectionChange<IFlatNode>): void {
		if (change.added) {
			change.added.forEach((node) => this.loadChildren(node));
		}
	}

	loadChildren(node: IFlatNode): void {
		if (this.childrenLoadedSet.has(node)) {
			return;
		}
		node.loading = true;
		getChildren(node).subscribe((children) => {
			node.loading = false;
			const flattenedData = this.flattenedData.getValue();
			const index = flattenedData.indexOf(node);
			if (index !== -1) {
				flattenedData.splice(index + 1, 0, ...children);
				this.childrenLoadedSet.add(node);
			}
			this.flattenedData.next(flattenedData);
		});
	}

	disconnect(): void {
		this.flattenedData.complete();
	}
}
