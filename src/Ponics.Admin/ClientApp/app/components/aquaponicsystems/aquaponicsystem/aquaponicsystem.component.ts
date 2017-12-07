import { Component, Input } from "@angular/core";
import { AquaponicSystem } from "../../../Ponics.Api.dtos";

@Component({
    selector: 'app-aquaponicsystem',
    templateUrl: './aquaponicsystem.component.html'
})

export class AquaponicSystemComponent {
    @Input() aquaponicSystem: AquaponicSystem ;
}