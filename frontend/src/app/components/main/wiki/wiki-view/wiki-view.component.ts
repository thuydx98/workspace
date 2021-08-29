import { Component, OnInit } from '@angular/core';
import { MomentHelper } from 'src/app/common/helpers/moment.helper';
import { PostService } from 'src/app/services/post/post.service';
import { RouterService } from 'src/app/services/router.service';

@Component({
	selector: 'app-wiki-view',
	templateUrl: './wiki-view.component.html',
	styleUrls: ['./wiki-view.component.scss'],
})
export class WikiViewComponent implements OnInit {
	constructor(public postService: PostService, private routerService: RouterService) {}

	ngOnInit(): void {}

	onEdit = () => this.routerService.wikiEdit(this.postService.selectedPost?.id);

	formatDateTime = (dateInput: any): string => MomentHelper.formatDateTime(dateInput);
}
