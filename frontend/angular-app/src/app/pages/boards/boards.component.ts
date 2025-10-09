import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-threads',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="threads-page">
      <div class="container">
        <h1>Треды</h1>
        <p>Страница тредов в разработке...</p>
      </div>
    </div>
  `,
  styles: [`
    .threads-page {
      padding: 4rem 0;
      min-height: 50vh;
      display: flex;
      align-items: center;
      justify-content: center;
      text-align: center;
    }
    h1 {
      font-size: 2.5rem;
      margin-bottom: 1rem;
      color: #1e293b;
    }
    p {
      font-size: 1.125rem;
      color: #64748b;
    }
  `]
})
export class ThreadsComponent {}
