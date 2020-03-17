import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { CreateTournamentComponent } from '../tournament/create-tournament/create-tournament.component';
import { HomeComponent } from '../home/home.component';
import { CounterComponent } from '../counter/counter.component';
import { FetchDataComponent } from '../fetch-data/fetch-data.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'createtournament', component: CreateTournamentComponent},
  //{ path: '', redirectTo: '/createtournament', pathMatch: 'full' },  
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ],
  declarations: []
})
export class RoutingModule { }
