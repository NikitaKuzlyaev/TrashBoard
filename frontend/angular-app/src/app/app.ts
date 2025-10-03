import { Component, signal, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/env';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  //protected readonly title = signal('angular-app');
  protected readonly randomValue = signal<number | null>(null);
  private readonly http = inject(HttpClient);

  fetchRandom() {
    this.http.get<{ value: number }>(`${environment.apiBaseUrl}/random`)
      .subscribe((res) => this.randomValue.set(res.value));
  }
}
