import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateTournamentComponent } from './create-tournament/create-tournament.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './../material/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { TournamentService } from './tournament.service';
import { GenericService } from '../services/generic.service';

@NgModule({
  declarations: [CreateTournamentComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    FlexLayoutModule,    
  ],
  providers: [
    GenericService,
    TournamentService
  ]
})
export class TournamentModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: TournamentModule,
      providers: [
        GenericService,
        TournamentService
      ]
    }
  }
}
