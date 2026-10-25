import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { provideHttpClient, withInterceptorsFromDi, withXhr } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {MaterialModule} from "./material/material.module";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LayoutModule } from '@angular/cdk/layout';
import { PessoaFisicaComponent } from './pessoa-fisica/pessoa-fisica.component';
import { PessoaJuridicaComponent } from './pessoa-juridica/pessoa-juridica.component';
import { MaquinaComponent } from './maquina/maquina.component';
import { HomeComponent } from './home/home.component';

import { MatConfirmDialogComponent } from './mat-confirm-dialog/mat-confirm-dialog.component';
import { RegimeTributarioModule } from './regime-tributario/regime-tributario.module';
import { MaquinaModule } from './maquina/maquina.module';
import { PessoaFisicaModule } from './pessoa-fisica/pessoa-fisica.module';
import { PessoaJuridicaListComponent } from './pessoa-juridica/pessoa-juridica-list/pessoa-juridica-list.component';
import { PessoaJuridicaDetailComponent } from './pessoa-juridica/pessoa-juridica-detail/pessoa-juridica-detail.component';
import { PessoaJuridicaModule } from './pessoa-juridica/pessoa-juridica.module';
import { BoardAssistenciaTecnicaModule } from './board-assistencia-tecnica/board-assistencia-tecnica/board-assistencia-tecnica.module';
import { FuncionarioModule } from './funcionario/funcionario.module';
import { CategoriaModule } from './categoria/categoria.module';
import { ComponenteModule } from './componente/componente.module';
import localePt from '@angular/common/locales/pt';
import { registerLocaleData } from '@angular/common';
import { EstoqueModule } from './estoque/estoque.module';
import { BoardGarantiaModule } from './board-garantia/board-garantia.module';
import { MainNavComponent } from './main-nav/main-nav.component';
import { AssistenciaTecnicaModule } from './assistencia-tecnica/assistencia-tecnica.module';
import { ProblemaModule } from './problema/problema.module';
import { SecurityModule } from './security/security.module';
import { SharedModule } from './shared/shared-module/shared.module';
import { ClienteAssociadoModule } from './cliente-associado/cliente-associado.module';
import { EtiquetaModule } from './etiqueta/etiqueta.module';
import { ComprovanteCompraModule } from './comprovante-compra/comprovante-compra.module';
import { EntreguePorModule } from './entregue-por/entregue-por.module';
import { AcessorioComponent } from './acessorio/acessorio.component';
import { AcessorioModule } from './acessorio/acessorio.module';

registerLocaleData(localePt);

@NgModule({ declarations: [
        AppComponent,
        MainNavComponent,
        HomeComponent,
        MatConfirmDialogComponent
    ],
    bootstrap: [AppComponent], imports: [BrowserModule,
        AppRoutingModule,
        MaterialModule,
        SharedModule,
        RouterModule.forRoot([
            // { path: 'pessoa-juridica', component: PessoaJuridicaComponent },      
            { path: 'app-home', component: HomeComponent },
            { path: '', redirectTo: 'app-home', pathMatch: 'full' },
            { path: '**', redirectTo: 'app-home', pathMatch: 'full' }
        ], {}),
        BrowserAnimationsModule,
        LayoutModule,
        RegimeTributarioModule, MaquinaModule,
        PessoaFisicaModule, PessoaJuridicaModule,
        BoardAssistenciaTecnicaModule, FuncionarioModule,
        CategoriaModule, ComponenteModule, EstoqueModule, BoardGarantiaModule,
        AssistenciaTecnicaModule,
        ProblemaModule,
        SecurityModule,
        ClienteAssociadoModule,
        EtiquetaModule,
        ComprovanteCompraModule,
        EntreguePorModule,
        AcessorioModule], providers: [provideHttpClient(withXhr(), withInterceptorsFromDi())] })

export class AppModule { }
