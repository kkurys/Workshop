import { NgModule } from '@angular/core';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { 
    MatCardModule, 
    MatButtonModule, 
    MatInputModule, 
    MatFormFieldModule,
    MatStepperModule,
    MatListModule,
    MatExpansionModule, 
    MatAutocompleteModule,
    MatDialogModule,
    MatSelectModule, 
    MatGridListModule,
    MatSnackBarModule,
    MatIconModule}

from '@angular/material';

@NgModule({
    imports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatStepperModule,
        MatListModule,
        MatExpansionModule,
        MatAutocompleteModule,
        MatDialogModule,
        MatSelectModule,
        MatGridListModule,
        MatSnackBarModule,
        MatIconModule
    ],
    exports: [
        MatCardModule,
        BrowserAnimationsModule,
        MatButtonModule,
        MatInputModule,
        MatFormFieldModule,
        MatStepperModule,
        MatListModule,
        MatExpansionModule,
        MatAutocompleteModule,
        MatDialogModule,
        MatSelectModule,
        MatGridListModule,
        MatSnackBarModule,
        MatIconModule
    ]
})
export class MaterialModule { }