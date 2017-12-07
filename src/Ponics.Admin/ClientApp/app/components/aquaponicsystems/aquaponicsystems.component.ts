import { Component } from "@angular/core";
import {AquaponicSystem} from "../../Ponics.Api.dtos";

@Component({
    templateUrl: './aquaponicsystems.component.html'
})

export class AquaponicSystemsComponent {
    allowNewAquaponicSystem = false;

    aquaponicSystems: AquaponicSystem[] = [];

    onAquaponicSystemaAdded(newAquaponicSystem: AquaponicSystem) {
        this.aquaponicSystems.push(newAquaponicSystem);
    }
}