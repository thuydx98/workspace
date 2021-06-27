import { Component, OnInit, Input, Output,EventEmitter } from '@angular/core';

@Component({
  selector: 'app-add-income-modal',
  templateUrl: './add-income-modal.component.html',
})
export class AddIncomeModalComponent implements OnInit {
  isOkLoading = false;

  @Input() isVisible: boolean = false;
  @Output() closeModal = new EventEmitter();

  constructor() {}

  ngOnInit(): void {}

  handleOk(): void {
    this.isOkLoading = true;
    setTimeout(() => {
      this.closeModal.emit();
      this.isVisible = false;
      this.isOkLoading = false;
    }, 3000);
  }

  handleCancel(): void {
    this.closeModal.emit();
    this.isVisible = false;
    console.log('inside')
  }
}
