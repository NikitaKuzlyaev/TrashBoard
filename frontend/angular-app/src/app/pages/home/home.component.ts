import { Component, signal, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/env';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  protected readonly randomValue = signal<number | null>(null);
  protected readonly isLoading = signal<boolean>(false);
  private readonly http = inject(HttpClient);

  fetchRandom() {
    this.isLoading.set(true);
    this.http.get<{ value: number }>(`${environment.apiBaseUrl}/random`)
      .subscribe({
        next: (res) => {
          this.randomValue.set(res.value);
          this.isLoading.set(false);
        },
        error: (error) => {
          console.error('Error fetching random number:', error);
          this.isLoading.set(false);
        }
      });
  }
}
