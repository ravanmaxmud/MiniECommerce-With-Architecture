import { Component } from '@angular/core';
import { AlertifyService,MessageType } from 'src/app/services/admin/alertify.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {
  constructor(private alertify: AlertifyService){}

  ngOnInit():void{
    // this.alertify.message("HelloWorld!",MessageType.Error);
  }
  m(){
    this.alertify.message("HelloWorld!",MessageType.Error);
  }
}
