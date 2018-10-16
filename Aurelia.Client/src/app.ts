import { RouterConfiguration, Router } from 'aurelia-router';

import "toastr/build/toastr.css";
import "font-awesome/css/font-awesome.css";


import { ToastrService } from 'aurelia-toolbelt';
import { autoinject } from 'aurelia-dependency-injection';
import { PLATFORM } from 'aurelia-pal';

import { User } from "oidc-client";
import { OpenIdConnect, OpenIdConnectRoles } from "aurelia-open-id-connect";

@autoinject()
export class App {

  private router: Router;
  private user: User;

  constructor(private openIdConnect: OpenIdConnect) {
    this.openIdConnect.observeUser((user: User) => this.user = user);
  }

  private configureRouter(config: RouterConfiguration, router: Router): void {


    // switch from hash (#) to slash (/) navigation
    config.options.pushState = true;

    config.title = 'Title';
    config.map([
      {
        route: '/home', name: 'home',
        moduleId: PLATFORM.moduleName('./routes/home/home'),
        nav: true, title: 'Home',  settings: {
          roles: [OpenIdConnectRoles.Authenticated]
        }
      },
      {
        route: '/login', name: 'login',
        moduleId: PLATFORM.moduleName('./routes/auth/login'),
        nav: true, title: 'Login'
      },
      {
        route: '/logout', name: 'logout',
        moduleId: PLATFORM.moduleName('./routes/auth/logout'),
        nav: true, title: 'Logout'
      }
    ]);

    this.openIdConnect.configure(config);
    this.router = router;

  }
}
