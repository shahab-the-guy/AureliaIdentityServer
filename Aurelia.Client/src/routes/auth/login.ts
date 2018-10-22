
import { OpenIdConnect } from 'aurelia-open-id-connect';
import { autoinject } from 'aurelia-framework';


@autoinject()
export class Login {

  constructor(private openIdConnect: OpenIdConnect) { }

  private login() {
    this.openIdConnect.login();
  }
}
