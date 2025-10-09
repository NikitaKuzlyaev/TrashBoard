import { Component, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

interface ThreadDto {
  id: number;
  name: string;
  publishedAt: string;
}

@Component({
  selector: 'app-threads',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="threads-page">
      <div class="container">
        <h1>Треды</h1>
        <ng-container *ngIf="isLoading(); else threadsList">
          <p>⏳ Загрузка тредов...</p>
        </ng-container>
        <ng-template #threadsList>
          <ng-container *ngIf="threads().length > 0; else noThreads">
            <ul style="list-style:none;padding:0;max-width:600px;margin:20px auto 0 auto;">
              <li *ngFor="let thread of threads()" style="padding:12px 0;border-bottom:1px solid #cfd9ec;display:flex;justify-content:space-between;align-items:center;">
                <span style="font-weight:500">{{ thread.name }}</span>
                <span style="color:#64748b;font-size:0.92rem">{{ thread.publishedAt | date:'short' }}</span>
              </li>
            </ul>
          </ng-container>
          <ng-template #noThreads><p>Нет доступных тредов.</p></ng-template>
        </ng-template>
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
  `]
})
export class ThreadsComponent {
  protected readonly threads = signal<ThreadDto[]>([]);
  protected readonly isLoading = signal(true);
  private readonly http = inject(HttpClient);

  constructor() {
    this.http.get<ThreadDto[]>('/api/thread/latest-public').subscribe({
      next: (data) => {
        this.threads.update(() => data);
        this.isLoading.update(() => false);
      },
      error: (e) => {
        this.isLoading.update(() => false);
        // можно обработать ошибку отображением alert или текста
      }
    });
  }
}
