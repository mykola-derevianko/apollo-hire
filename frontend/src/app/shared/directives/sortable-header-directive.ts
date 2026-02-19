import { Directive, input, output } from '@angular/core';

export type SortDirection = 'ASC' | 'DESC' | '';

export interface SortEvent {
  column: string;
  direction: SortDirection;
}

@Directive({
  selector: 'th[sortable]',
  host: {
    '(click)': 'rotate()',
    'style': 'cursor: pointer; user-select: none;',
  },
})
export class SortableHeaderDirective {
  readonly sortable = input.required<string>();
  readonly currentColumn = input<string>('');
  readonly currentDirection = input<SortDirection>('');
  readonly sort = output<SortEvent>();

  rotate() {
    let direction: SortDirection;

    if (this.currentColumn() !== this.sortable()) {
      direction = 'ASC';
    } else {
      direction = this.currentDirection() === 'ASC' ? 'DESC' : 'ASC';
    }

    this.sort.emit({ column: this.sortable(), direction });
  }
}
