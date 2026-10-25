import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { AppUser } from './app-user';
import { AppUserAuth } from './app-user-auth';
import { SecurityService } from './security.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'ptc-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    changeDetection: ChangeDetectionStrategy.Eager,
    standalone: false
})



export class LoginComponent implements OnInit {

  user: AppUser = new AppUser();
  securityObject: AppUserAuth = null;
  returnUrl: string;
  urlHome: string = "http://localhost:4200/app-home";  
  showSpinner = false;

  constructor(private securityService: SecurityService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.returnUrl = this.route.snapshot.queryParamMap.get('returnUrl');
  }

  login() {
    this.showSpinner = true;
    this.securityService.login(this.user)
      .subscribe({
        next: resp => {
          this.showSpinner = false;
          this.securityObject = resp;
          if (this.returnUrl) {
            this.router.navigateByUrl(this.returnUrl);
          } else {
            this.router.navigateByUrl(this.urlHome);
          }
        },
        error: () => {
          this.showSpinner = false;
          this.securityObject = new AppUserAuth();
        }
      });
  }

}
