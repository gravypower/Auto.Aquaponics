
import { Component } from 'angular/core';

@Component({
    selector: 'all-systems-component',
    template: 'Hello my name is {{name}}.'
})
export class ExampleComponent {
    constructor() {
        this.name = 'Sam';
    }
}
