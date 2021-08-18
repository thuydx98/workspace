export class FundModel {
    public id: string;
    public name: string;
    public type?: string;
    public total?: number;
    public invest?: number;
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
    public note: string;
    public at: Date;
}

export class AddFundHistoryModel {
    public type: string;
    public amount: number;
    public at: Date;
}

export class FundInvestModel {
    public id: string;
    public status: string;
    public name: string;
    public amount: number;
    public criteria: string[];
    public note: string;
    public investedAt: Date;
}

export class AddFundInvestModel {
    
}