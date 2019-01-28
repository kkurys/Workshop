import { Component, Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material';

@Component({
    selector: 'message-snack-bar',
    templateUrl: 'message-snack-bar.component.html',
    styles: [``],
})
export class MessageSnackBarComponent {
    message: String;
    danger = false;
    warning = false;
    success = false;

    constructor(
        @Inject(MAT_SNACK_BAR_DATA) public data: any
    ) {
        this.message = data.message;
        if (data.messageType === 'danger'){
            this.danger = true;
        }
        else if (data.messageType === 'warning'){
            this.warning = true;
        }
        else if (data.messageType === 'success'){
            this.success = true;
        }
    }
}