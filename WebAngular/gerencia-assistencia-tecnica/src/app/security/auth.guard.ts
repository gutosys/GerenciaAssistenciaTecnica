import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { SecurityService } from './security.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard  {
  constructor(private securityService: SecurityService,
              private router: Router) { }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    // Get property name on security object to check
    let claimType: string = next.data["claimType"];

    //Verifica se o usuário está autenticado e se o tipo de claim dele pode acessar esta funcionalidade
    if (this.securityService.securityObject.isAuthenticated
      && this.securityService.hasClaim(claimType)) {
      return true;
    }
    else { //Se não, vai para a tela de login, e se ele tiver permissão, após logar já direciona para a página que estava querendo acessar
      this.router.navigate(['login'],
        { queryParams: { returnUrl: state.url } }); //o state pega a url que havia sido digitada no browser
      return false;
    }
  }

}
