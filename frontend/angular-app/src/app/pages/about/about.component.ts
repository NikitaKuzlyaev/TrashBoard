import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-about',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="about-page">
      <div class="container">
        <h1>О проекте</h1>
        <p>Страница о проекте в разработке...</p>
      </div>
    </div>
  `,
  styles: [`
    .about-page {
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
export class AboutComponent {}
