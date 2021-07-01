import { Component, OnInit } from '@angular/core';
import { PagingListModel } from 'src/app/models/app/paging-list.model';
import { AssetModel } from 'src/app/models/asset/asset.model';
import { AssetService } from 'src/app/services/asset/asset.service';

@Component({
  selector: 'app-asset',
  templateUrl: './asset.component.html',
  styleUrls: ['./asset.component.scss'],
})
export class AssetComponent implements OnInit {
  public addIncomeModalVisible = false;
  public assetHistories: PagingListModel<AssetModel>;

  constructor(private assetService: AssetService) {}

  ngOnInit(): void {
    this.assetService
      .getPagingList()
      .subscribe((res: PagingListModel<AssetModel>) => {
        this.assetHistories = res;
      });
  }

  updateAssetHistories(asset: AssetModel) {
    this.addIncomeModalVisible = false;
    if (!asset) {
      return;
    }

    this.assetHistories.items.unshift(asset);
  }

  onChangePage(data: any) {
    const { pageIndex } = data;
    this.assetService
      .getPagingList(pageIndex)
      .subscribe((res: PagingListModel<AssetModel>) => {
        this.assetHistories = res;
      });
  }
}
