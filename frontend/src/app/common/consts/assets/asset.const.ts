export const ASSET_HISTORY_TYPE = {
	ASSET_INCOME: 'INCOME',
	ASSET_SPEND: 'SPEND',
	FUND_RECHARGE: 'RECHARGE',
	FUND_WITHDRAW: 'WITHDRAW',
};

export const InvestUpdateType = {
	AUTO: 'AUTO',
	MANUAL: 'MANUAL',
};

export const InvestStatus = {
	FOLLOWING: 'FOLLOWING',
	INVESTING: 'INVESTING',
	COMPLETED: 'COMPLETED',
};

export const InvestStatusList = [
	// { label: 'THEO DÕI', value: InvestStatus.FOLLOWING, checked: true },
	{ label: 'ĐANG ĐẦU TƯ', value: InvestStatus.INVESTING },
	{ label: 'ĐÃ CHỐT', value: InvestStatus.COMPLETED },
];
