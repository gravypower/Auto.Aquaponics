import { Component, Input } from "@angular/core";

@Component({
    selector: 'app-aquaponicsystemlist',
    templateUrl: './aquaponicsystemlist.component.html'
})

export class AquaponicSystemListComponent {
    @Input() name: string = "";
}