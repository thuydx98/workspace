import { Component, OnInit } from '@angular/core';

interface DataItem {
  name: string;
  chinese: number;
  math: number;
  english: number;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  addIncomeModalVisible = false;

  dataSet = [
    {
      amount: 10000,
      time: 'May 06 2021',
      note: 'New York No. 1 Lake Park',
    },
  ];

  constructor() {}

  ngOnInit(): void {}

  onAddIncome() {
  }
}
