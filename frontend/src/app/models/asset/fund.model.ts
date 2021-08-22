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
	public fundId: string;
	public status: string;
	public name: string;
	public updateType: string;
	public capitalPrice: number;
	public marketPrice?: number;
	public sellPrice?: number;
	public amount: number;

	public criteria: string[];
	public note: string;
	public followedAt?: Date;
	public investedAt?: Date;
	public completedAt?: Date;

	public sellFeePercent: number = 0;
	public buyFeePercent: number = 0;

	public totalCapital: number = 0;
	public finalProfitPercent: number = 0;
	public finalProfit: number = 0;

	public revenueCycle: number;
	public revenuePercent: number;

	public stopLossPercent: number;
	public takeProfitPercent: number;
	public trailingStopLossPercent: number;
}

export class AddFundInvestModel {}
