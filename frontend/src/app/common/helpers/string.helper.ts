export const formatMoney = (input: number | string): string => {
	if (!input) {
		return '0';
	}

	return input.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,');
};
