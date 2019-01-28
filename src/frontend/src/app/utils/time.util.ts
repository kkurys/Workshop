import * as moment from 'moment';

export class TimeUtil {
    formatDate = (date) => {
        return moment(date).format('DD.MM.YYYY HH:mm:ss');
    };
}