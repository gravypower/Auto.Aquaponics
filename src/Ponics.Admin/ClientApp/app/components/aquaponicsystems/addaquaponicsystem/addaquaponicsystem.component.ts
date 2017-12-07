import { Component, EventEmitter, Output } from "@angular/core";
import { AquaponicSystem } from "../../../Ponics.Api.dtos";

@Component({
    selector: 'app-addaquaponicsystem',
    templateUrl: './addaquaponicsystem.component.html'
})

export class AddAquaponicSystemComponent {
    @Output() aquaponicSystemaAdded = new EventEmitter<AquaponicSystem>();
    newAquaponicSystem = new AquaponicSystem();

    onCreateAquaponicSystem() {
        this.aquaponicSystemaAdded.emit(this.newAquaponicSystem);
    }
}