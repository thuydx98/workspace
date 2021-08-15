export class FundModel {
    public id: string;
    public name: string;
    public type?: string;
    public total?: number;
    public balance?: number;
}

export class AddFundModel {
    public type?: string;
    public name: string;
    public avatar?: string;
}

export class FundHistoryModel {
    public id: string;
    public type: string;
    public amount: number;
    public at: Date;
}

export class AddFundHistoryModel {
    public type: string;
    public amount: number;
    public at: Date;
}