import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTabsModule, MatSidenavModule, MatToolbarModule, MatIconModule, MatButtonModule, MatListModule, MatMenuModule, MatCardModule, MatPaginatorModule, MatTableModule, MatDividerModule } from '@angular/material';

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
  ],
  declarations: []
})
export class MaterialModule { }
