import { Component, Input, OnInit } from '@angular/core';
import { ISchedule } from 'src/app/shared/models/schedule';
import { IScheduleRow } from 'src/app/shared/models/schedule-row';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.sass']
})
export class ScheduleComponent implements OnInit {
  @Input() schedule: ISchedule;
  
  readonly rowsPerPage: number = 12;
  rowsAmount: number;
  pagesAmount: number;

  rowsForDisplay: IScheduleRow[] = [];

  loanAmount: number;

  currentPagerPage = 1;

  constructor() {
  }

  ngOnInit() {
    this.calculateTotalPrincipal();

    this.rowsAmount = this.schedule.schedule.length;
    this.pagesAmount = Math.ceil(this.rowsAmount / this.rowsPerPage);

    this.rowsForDisplay = this.schedule.schedule.slice(0, this.rowsPerPage);

  }

  calculateTotalPrincipal() {
    this.loanAmount = this.schedule.schedule.map(s => s.principal).reduce((prev, curr, i) => prev + curr)
    this.loanAmount = Math.round(this.loanAmount);
  }

  onPageChange(event) {
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.rowsForDisplay = this.schedule.schedule.slice(startItem, endItem);
  }

  pagePagerChanged() {
    
  }


}