import { Injectable, TemplateRef } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AppToastService
{
  toasts: any[] = [];

  show(textOrTpl: string | TemplateRef<any>, options: any = {})
  {
    this.toasts.push({ textOrTpl, ...options });
  }

  //show(header: string, body: string)
  //{
  //  this.toasts.push({ header, body });
  //}

  remove(toast: any)
  {
    this.toasts = this.toasts.filter(t => t !== toast);
  }
}
