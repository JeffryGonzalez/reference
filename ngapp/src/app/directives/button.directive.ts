import { Directive, ElementRef, Input } from '@angular/core';

type ButtonIntents = 'primary' | 'secondary';

const intentMap = {
  'primary': 'btn-primary',
  'secondary': 'btn-secondary'
}
@Directive({
  selector: 'button[appButton]',
  standalone: true
})
export class ButtonDirective {
  @Input() intent: ButtonIntents = 'primary';
  constructor(private el: ElementRef) { 
    const b = el.nativeElement as HTMLButtonElement;
    b.classList.add('btn', intentMap[this.intent])
  }

}


