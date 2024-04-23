import { Component } from '@angular/core';
import { AlertifyService, MessageType } from 'src/app/services/admin/alertify.service';
declare var alertify: any;

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent {
  constructor(private alertify: AlertifyService){
    // this.alertify.message("Salam",MessageType.Success)
  };

   ngOnInit(): void{
    // alertify.success('Success message');
   }
}
