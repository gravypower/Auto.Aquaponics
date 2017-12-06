import { Component, Input } from "@angular/core";

@Component({
    selector:"app-alert",
    templateUrl: './alert.component.html'
})

export class AlertComponent {
    @Input() alertType: string;
    @Input() message: String;

}

enum AlertTypes {
    Success = "alert-success",
    Warning = "alert-warning"
}