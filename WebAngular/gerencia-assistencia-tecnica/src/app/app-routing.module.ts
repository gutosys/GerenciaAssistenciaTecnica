import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CategoriaComponent } from './categoria/categoria.component';
import { AuthGuard } from './security/auth.guard';
import { RegimeTributarioComponent } from './regime-tributario/regime-tributario.component';
import { MaquinaComponent } from './maquina/maquina.component';
import { ProblemaComponent } from './problema/problema.component';
import { PessoaFisicaComponent } from './pessoa-fisica/pessoa-fisica.component';
import { PessoaJuridicaComponent } from './pessoa-juridica/pessoa-juridica.component';
import { FuncionarioComponent } from './funcionario/funcionario/funcionario.component';
import { ComponenteComponent } from './componente/componente.component';
import { EstoqueComponent } from './estoque/estoque.component';
import { EntradaAssistenciaComponent } from './assistencia-tecnica/entrada-assistencia/entrada-assistencia.component';
import { BoardAssistenciaTecnicaComponent } from './board-assistencia-tecnica/board-assistencia-tecnica/board-assistencia-tecnica.component';
import { BoardGarantiaComponent } from './board-garantia/board-garantia.component';
import { ClienteAssociadoComponent } from './cliente-associado/cliente-associado.component';
import { EtiquetaComponent } from './etiqueta/etiqueta.component';
import { ComprovanteCompraComponent } from './comprovante-compra/comprovante-compra.component';
import { EntreguePorComponent } from './entregue-por/entregue-por.component';
import { AcessorioComponent } from './acessorio/acessorio.component';

const routes: Routes = [ 
  {
    path: 'regime-tributario',
    component: RegimeTributarioComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'CanAccessRegimeTributario' }
  },
  {
    path: 'acessorio',
    component: AcessorioComponent,
    //canActivate: [AuthGuard],
    //data: { claimType: 'CanAccessAcessorio' }
  },
  {
    path: 'maquina', component: MaquinaComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'CanAccessMaquina' }
  },
  {
    path: 'problema', component: ProblemaComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'CanAccessProblema' }
  },
  {
    path: 'pessoa-fisica', component: PessoaFisicaComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'CanAccessPessoaFisica' }
  },
  {
    path: 'pessoa-juridica', component: PessoaJuridicaComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'CanAccessPessoaJuridica' }
  },
  {
    path: 'funcionario', component: FuncionarioComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'CanAccessFuncionario' },
  },
  {
    path: 'categoria',
    component: CategoriaComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'canAccessCategoria' }
  },
  {
    path: 'componente', component: ComponenteComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'canAccessComponente' }
  },
  {
    path: 'estoque', component: EstoqueComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'canAccessEstoque' }
  },
  {
    path: 'entrada-assistencia', component: EntradaAssistenciaComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'canAccessEntradaAssistencia' }
  },
  {
    path: 'board-assistencia-tecnica', component: BoardAssistenciaTecnicaComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'canAccessBoardAssistencia' }
  },
  {
    path: 'cliente-associado', component: ClienteAssociadoComponent,
    // canActivate: [AuthGuard],
    // data: { claimType: 'CanAccessBoardGarantia' }
  },    
  {
    path: 'comprovante-compra', component: ComprovanteCompraComponent,
    // canActivate: [AuthGuard],
    // data: { claimType: 'CanAccessBoardGarantia' }
  },
  {
    path: 'entregue-por', component: EntreguePorComponent,
    // canActivate: [AuthGuard],
    // data: { claimType: 'CanAccessBoardGarantia' }
  },
  {
    path: 'board-garantia', component: BoardGarantiaComponent,
    canActivate: [AuthGuard],
    data: { claimType: 'CanAccessBoardGarantia' }
  },
]

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule]
})

export class AppRoutingModule { }
