
import "toastr/build/toastr.css";
import "font-awesome/css/font-awesome.css";


import { ToastrService } from 'aurelia-toolbelt';
import { inject } from 'aurelia-dependency-injection';

@inject(ToastrService)
export class App {
  message = 'Hello World!';

  constructor(private ts: ToastrService) {
  }

  alertMessage() {
    this.ts.success('Thanks buddy :+1:');
  }
}
