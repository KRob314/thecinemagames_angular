import { Component, OnInit, TemplateRef } from '@angular/core';
import { AppToastService } from '../app-toast.service';

@Component({
  selector: 'app-toast',
  templateUrl: './app-toast.component.html',
  styleUrls: ['./app-toast.component.css']
})
export class AppToastComponent implements OnInit {

  constructor(public toastService: AppToastService) { }

  ngOnInit(): void {
  }

  isTemplate(toast: any) { return toast.textOrTpl instanceof TemplateRef; }

  //showStandard()
  //{
  //  this.toastService.show('I am a standard toast');
  //}

  //showSuccess()
  //{
  //  this.toastService.show('I am a success toast', { classname: 'bg-success text-light', delay: 10000 });
  //}

  //showDanger(dangerTpl)
  //{
  //  this.toastService.show(dangerTpl, { classname: 'bg-danger text-light', delay: 15000 });
  //}

}

