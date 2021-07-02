import { FundHistoryType } from "src/app/common/enums/fund-history-type.enum";

export class FundModel {
    public id: string;
    public name: string;
    public total?: number;
}

export class FundHistoryModel {
    public id: string;
    public type: FundHistoryType;
    public amount: number;
    public at: Date;
}

export class AddFundHistoryModel {
    public type: FundHistoryType;
    public amount: number;
    public at: Date;
}