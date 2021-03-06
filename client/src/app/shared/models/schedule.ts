import { ILoanApplication } from "./loan-application";
import { IScheduleRow } from "./schedule-row";

export interface ISchedule {
  title: string,
  totalToPay: number,
  totalInterestToPay: number,
  scheduleTable: IScheduleRow[],
  application: ILoanApplication
  
}