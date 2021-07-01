export class PagingListModel<T> {
  public page: number;
  public size: number;
  public total: number;
  public items: T[];

  constructor(
    page: number = 1,
    size: number = 10,
    total: number = 0
  ) {
    this.page = page;
    this.size = size;
    this.total = total;
    this.items = [];
  }
}
