
import { OpenIdConnect } from 'aurelia-open-id-connect';
import { autoinject } from 'aurelia-framework';


@autoinject()
export class Login {

  constructor(private openIdConnect: OpenIdConnect) {

  }

  private login() {
    // return new Promise((resolve, reject) => {
    //   console.log('Log');
    this.openIdConnect.login();
    //   .then(_ => {
    //     resolve();
    //   }).catch(_ => {
    //     alert('Login failed');
    //     reject();
    //   });
    // });
  }

}
