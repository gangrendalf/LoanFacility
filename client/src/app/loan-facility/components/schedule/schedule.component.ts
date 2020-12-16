import { Component, Input, OnChanges } from '@angular/core';
import { ISchedule } from 'src/app/shared/models/schedule';
import { IScheduleRow } from 'src/app/shared/models/schedule-row';

@Component({
  selector: 'app-schedule',
  templateUrl: './schedule.component.html',
  styleUrls: ['./schedule.component.sass']
})
export class ScheduleComponent implements OnChanges{
  @Input() schedule: ISchedule;
  
  rowsPerPage: number = 12;
  rowsAmount: number;
  rowsForDisplay: IScheduleRow[] = [];

  constructor() { }

  ngOnChanges() {
    this.rowsAmount = this.schedule.schedule.length;
    this.onRowsPerPageSelect();
  }

  onPageChange(event) {
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.rowsForDisplay = this.schedule.schedule.slice(startItem, endItem);
  }

  onRowsPerPageSelect() {
    const startItem = 0;
    const endItem = this.rowsPerPage;
    this.rowsForDisplay = this.schedule.schedule.slice(startItem, endItem);
  }

  printSchedule() {
    window.print();
  }
}
