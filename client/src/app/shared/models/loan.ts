export interface ILoan {
  name: string,
  interestPerYear: number,
  minDurationInMonths: number,
  maxDurationInMonths: number,
  minAmountInMonths: number,
  maxAmountInMonths: number
}