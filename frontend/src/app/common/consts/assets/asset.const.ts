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
	INVESTING: 'INVESTING',
	COMPLETED: 'COMPLETED',
	FOLLOWING: 'FOLLOWING',
};

export const InvestStatusList = [
	{ label: 'ĐANG ĐẦU TƯ', value: InvestStatus.INVESTING, checked: true },
	{ label: 'ĐÃ CHỐT', value: InvestStatus.COMPLETED },
	{ label: 'THEO DÕI', value: InvestStatus.FOLLOWING },
];
