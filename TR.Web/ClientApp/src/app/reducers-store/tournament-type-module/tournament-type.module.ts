import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import * as fromtournamentType from './tournament-type/tournament-type.reducers';
import { EffectsModule } from '@ngrx/effects';
import { TournamentTypeEffects } from './tournament-type/tournament-type.effect';
import { ModuleWithProviders } from '@angular/compiler/src/core';
import { GenericService } from '../../services/generic.service';
import { TournamentTypeReducerService } from './tournament-type-reducer.service';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    //StoreModule.forRoot({}),
    //EffectsModule.forRoot([]),
    StoreModule.forFeature('tournamentTypeReducer', fromtournamentType.TournamentTypeReducer),
    EffectsModule.forFeature([
      TournamentTypeEffects
    ])
  ]
})

export class TournamentTypeModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: TournamentTypeModule,
      providers: [
        GenericService,
        TournamentTypeReducerService
      ]
    }
  }
}
  
  
