import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import * as fromtournament from './tournament/tournament.reducers';
import { EffectsModule } from '@ngrx/effects';
import { TournamentEffects } from './tournament/tournament.effect';
import { ModuleWithProviders } from '@angular/compiler/src/core';
import { GenericService } from '../../services/generic.service';
import { TournamentReducerService } from './tournament-reducer.service';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,    
    StoreModule.forFeature('tournamentReducer', fromtournament.TournamentReducer),
    EffectsModule.forFeature([
      TournamentEffects
    ])
  ]
})

export class TournamentModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: TournamentModule,
      providers: [
        GenericService,
        TournamentReducerService
      ]
    }
  }
}
  
  
