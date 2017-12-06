import { Component, Input } from "@angular/core";

@Component({
    selector: 'app-aquaponicsystem',
    templateUrl: './aquaponicsystem.component.html'
})

export class AquaponicSystemComponent {
    @Input() name: string = "";
}