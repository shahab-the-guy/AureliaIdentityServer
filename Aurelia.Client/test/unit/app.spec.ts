import { App } from '../../src/app';

import { ToastrService } from 'aurelia-toolbelt';
import { Container } from 'aurelia-framework';


describe('the app', () => {
  it('says hello', () => {

    const ts: ToastrService = Container.instance.get(ToastrService);

    expect(new App(ts).message).toBe('Hello World!');
  });
});
