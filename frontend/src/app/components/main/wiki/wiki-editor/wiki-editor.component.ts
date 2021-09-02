import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { CKEditorComponent } from '@ckeditor/ckeditor5-angular';
import DocumentEditor from '@ckeditor/ckeditor5-build-decoupled-document';
import { PostModel } from 'src/app/models/post/post.model';
import { PostService } from 'src/app/services/post/post.service';
import { RouterService } from 'src/app/services/router.service';

@Component({
	selector: 'app-wiki-editor',
	templateUrl: './wiki-editor.component.html',
	styleUrls: ['./wiki-editor.component.scss'],
})
export class WikiEditorComponent implements OnInit {
	post: PostModel;
	Editor = DocumentEditor;

	@ViewChild('editor', { static: false })
	public editorComponent: CKEditorComponent;

	constructor(private route: ActivatedRoute, private routerService: RouterService, private postService: PostService, private message: NzMessageService) {}

	ngOnInit(): void {
		this.route.params.subscribe((params) => {
			if (params) {
				if (this.postService.selectedPost && params['id'] === this.postService.selectedPost.id) {
					this.post = this.postService.selectedPost;
				} else {
					this.postService.get(params['id']).subscribe((res) => {
						this.post = this.postService.selectedPost;
					});
				}
			} else {
				this.routerService.notFound();
			}
		});
	}

	onReady(editor) {
		editor.ui.getEditableElement().parentElement.insertBefore(editor.ui.view.toolbar.element, editor.ui.getEditableElement());
	}

	onSave(): void {
		this.post.content = this.editorComponent.editorInstance.getData();

		this.postService.update(this.post.id, this.post).subscribe((res) => {
			if (res) {
				this.message.success('Lưu bài viết thành công');
				this.onBack();
			} else {
				this.message.error('Lưu bài viết thất bại');
			}
		});
	}

	onBack = () => this.routerService.wikiInfo(this.post.id);
}
