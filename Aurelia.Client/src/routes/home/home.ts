import { autoinject } from "aurelia-framework";
import { OpenIdConnect } from "aurelia-open-id-connect";



@autoinject()
export class Home{


  constructor(private openIdConnect: OpenIdConnect) {
  }


  private logout(){
    this.openIdConnect.logout();
  }


}
