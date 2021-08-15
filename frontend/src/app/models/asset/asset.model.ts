export class AssetOverviewModel {
    public income: number;
    public spent: number;
    public invest: number;
    public balance: number;
}

export class AssetModel {
    public id: string;
    public amount: number;
    public at: Date;
    public note: string;
    public type: string;
}

export class AddAssetModal {    
    public amount: number;
    public at: Date;
    public note: string;
}