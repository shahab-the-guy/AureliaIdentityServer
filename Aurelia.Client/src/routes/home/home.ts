import { autoinject } from "aurelia-framework";
import { OpenIdConnect } from "aurelia-open-id-connect";
import { HttpClient } from "aurelia-http-client";

@autoinject()
export class Home {

  private access_token;
  private frameworks: Array<any>;

  constructor(private openIdConnect: OpenIdConnect, private httpClient: HttpClient) { }

  private async activate() {
    this.access_token = (await this.openIdConnect.getUser()).access_token;

    this.httpClient.configure(config => {
      config.withBaseUrl("https://localhost:44346/")
        .withHeader('Accept', 'application/json')
        // adds the access token, so that we can call secure apis
        .withHeader('Authorization', `Bearer ${this.access_token}`); 
    });

    return this.httpClient.get('api/secure')
      .then(response => {
        this.frameworks = response.content;
      });

  }

  private logout() {
    this.openIdConnect.logout();
  }

}
