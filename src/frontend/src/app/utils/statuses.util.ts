import * as moment from 'moment';

export class StatusesUtil {
    getStatusName = (id) => {
        if (id === 0){
            return 'Oczekujące';
        } else if (id === 1) {
            return 'W trakcie realizacji';
        } else if (id === 2) {
            return 'Gotowe do odbioru';
        } else if (id === 3) {
            return 'Zakończone';
        }

        return '';
    };
}