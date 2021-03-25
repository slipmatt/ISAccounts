export interface ResponseModel {
    isSuccess: boolean;
    code: number;
    userInterfaceMessage: string;
    technicalMessage: string;
    returnObject: any[]
  }

export interface SearchModel {
  idNumber: string;
  surname: string;
  accountNumber: string;
}

export interface PersonModel {
    code: number;
    name: string;
    surname: string;
    idNumber: string;
    active: boolean;
  }

export interface AccountModel {
    code: number;
    personCode: number;
    accountNumber: string;
    balance: number;
    active: boolean;
  }

export interface TransactionModel {
    code: number;
    accountCode: number;
    transactionDate: Date;
    captureDate: Date;
    amount: number;
  }