export interface ILoan {
  name: string,
  interestPerYear: number,
  minDurationInMonths: number,
  maxDurationInMonths: number,
  minAmount: number,
  maxAmount: number
}