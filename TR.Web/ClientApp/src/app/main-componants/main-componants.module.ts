import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateTournamentComponent } from './create-tournament/create-tournament.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './../material/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { TournamentService } from './tournament.service';
import { GenericService } from './generic.service';

@NgModule({
  declarations: [CreateTournamentComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    FlexLayoutModule,
  ]
})
export class MainComponantsModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: MainComponantsModule,
      providers: [
        GenericService,
        TournamentService
      ]
    }
  }
}
