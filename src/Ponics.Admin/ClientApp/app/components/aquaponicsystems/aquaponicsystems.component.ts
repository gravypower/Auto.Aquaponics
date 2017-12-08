import { Component } from "@angular/core";
import {AquaponicSystem} from "../../Ponics.Api.dtos";

@Component({
    styleUrls: ['./aquaponicsystems.component.css'],
    templateUrl: './aquaponicsystems.component.html'
})

export class AquaponicSystemsComponent {
    selectedAquaponicSystem: AquaponicSystem;

    aquaponicSystems: AquaponicSystem[] = [];

    onAquaponicSystemAdded(newAquaponicSystem: AquaponicSystem) {
        this.aquaponicSystems.push(newAquaponicSystem);
    }

    onAquaponicSystemSelected(aquaponicSystem: AquaponicSystem) {
        this.selectedAquaponicSystem = aquaponicSystem;
    }
}