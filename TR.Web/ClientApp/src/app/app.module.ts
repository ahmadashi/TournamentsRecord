import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from "@angular/flex-layout";
import { MaterialModule } from './material/material.module';
import { HeaderComponent } from './navigation/header/header.component';
import { SidenavListComponent } from './navigation/sidenav-list/sidenav-list.component';
import { SidebarComponent } from './navigation/sidebar/sidebar.component';
import { FooterComponent } from './navigation/footer/footer.component';
import { RoutingModule } from './routing/routing.module';
import { StoreModule } from '@ngrx/store';
import { TournamentModule } from './tournament/tournament.module';
import { EffectsModule } from '@ngrx/effects';
import { SportTypeModule } from './reducers-store/sport-type-module/sport-type.module';
import { TournamentTypeModule } from './reducers-store/tournament-type-module/tournament-type.module';


@NgModule({
  declarations: [
    AppComponent,    
    HomeComponent,
    CounterComponent,
    FetchDataComponent,    
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    SidenavListComponent,
    SidebarComponent    
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RoutingModule,    
    BrowserAnimationsModule,
    FlexLayoutModule,
    MaterialModule,
    TournamentModule,    
    StoreModule,
    StoreModule.forRoot({}),
    EffectsModule.forRoot([]),
    SportTypeModule.forRoot(),
    TournamentTypeModule.forRoot(),
    TournamentModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
