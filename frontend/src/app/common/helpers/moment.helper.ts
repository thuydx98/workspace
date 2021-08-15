import * as moment from 'moment';
import { DateFormat } from '../consts/date-format.const';

export class MomentHelper {
    public static format(date: Date | moment.Moment | string | any, format: string = DateFormat.DateFormat): string {
        return moment(date).format(format);
    }

    public static formatDateTime(date: Date | moment.Moment | string | any, format: string = DateFormat.DateTimeFormat): string {
        return moment(date).format(format);
    } 
}
