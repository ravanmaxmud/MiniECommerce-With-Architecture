import { Injectable } from '@angular/core';
declare var alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {

  constructor() { }

   message(message: string, messageType : MessageType){
      alertify[messageType](message);
   }
}

export enum MessageType{
   Error = "error",
   Message = "message",
   Notify ="notify",
   Success = "success",
   Warning = "warning"
}
