import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  MatTabsModule, MatSidenavModule, MatToolbarModule, MatIconModule, MatButtonModule, MatListModule, MatMenuModule, MatCardModule, MatPaginatorModule, MatTableModule, MatDividerModule,
  MatFormFieldModule, MatInputModule
} from '@angular/material';

@NgModule({
  imports: [
    MatMenuModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    CommonModule,
    MatTabsModule,
    MatSidenavModule,
    MatCardModule,
    MatPaginatorModule,
    MatTableModule,
    MatSidenavModule,
    MatDividerModule,
    MatFormFieldModule,    
    MatInputModule
  ],
  exports: [
    MatMenuModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    MatTabsModule,
    MatSidenavModule,
    MatCardModule,
    MatPaginatorModule,
    MatTableModule,
    MatSidenavModule,
    MatDividerModule,
    MatFormFieldModule,
    MatInputModule
  ],
  declarations: []
})
export class MaterialModule { }
