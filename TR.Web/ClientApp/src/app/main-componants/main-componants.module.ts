import { NgModule, ModuleWithProviders } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateTournamentComponent } from './create-tournament/create-tournament.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './../material/material.module';
import { FlexLayoutModule } from '@angular/flex-layout';
import { TournamentService } from './tournament.service';
import { GenericService } from './generic.service';
import { StoreModule } from '@ngrx/store';
import * as fromSportType from './../reducers-store/sport-type/sport-type.reducers';
import { EffectsModule } from '@ngrx/effects';
import { SportTypeEffects } from '../reducers-store/sport-type/sport-type.effect';
@NgModule({
  declarations: [CreateTournamentComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MaterialModule,
    FlexLayoutModule,
    StoreModule.forRoot({}),
    EffectsModule.forRoot([]),
    StoreModule.forFeature('sportTypeReducer', fromSportType.SportTypeReducer),
    EffectsModule.forFeature([
      SportTypeEffects
    ]),
  ],
  providers: [
    GenericService,
    TournamentService
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
