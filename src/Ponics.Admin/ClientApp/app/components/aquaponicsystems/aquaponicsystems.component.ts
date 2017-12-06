import { Component } from "@angular/core";

@Component({
    templateUrl: './aquaponicsystems.component.html'
})

export class AquaponicSystemsComponent {
    allowNewAquaponicSystem = false;
    newAquaponicSystemName = "";
    aquaponicSystems = ['Aarons Aquaponic System', 'Aarons Aquaponic System2'];

    onCreateAquaponicSystem() {
        this.aquaponicSystems.push(this.newAquaponicSystemName);
    }
}