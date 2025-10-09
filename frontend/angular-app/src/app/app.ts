import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './components/header/header.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HeaderComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {}

function sparkleFirework(x: number, y: number) {
  const colors = ['#1969e6', '#deeafd', '#0840a7', '#63a1f7', '#bfcde9'];
  const container = document.createElement('div');
  container.style.position = 'absolute';
  container.style.pointerEvents = 'none';
  container.style.left = '0';
  container.style.top = '0';
  container.style.width = '100vw';
  container.style.height = '100vh';
  container.style.zIndex = '20000';

  // 8 "пикселей" в разные стороны
  for (let i = 0; i < 8; i++) {
    const particle = document.createElement('div');
    particle.style.position = 'fixed';
    particle.style.left = `${x - 2}px`;
    particle.style.top = `${y - 2}px`;
    particle.style.width = '6px';
    particle.style.height = '6px';
    particle.style.background = colors[i % colors.length];
    particle.style.borderRadius = '1.5px';
    particle.style.boxShadow = '0 0 1.5px #fff';
    particle.style.transition = 'transform 0.5s cubic-bezier(.36,2.06,.46,.72), opacity 0.3s';
    container.appendChild(particle);

    // Разлёт по кругу
    const angle = (i / 8) * 2 * Math.PI;
    setTimeout(() => {
      particle.style.transform = `translate(${Math.cos(angle)*26}px,${Math.sin(angle)*22}px) scale(0.6)`;
      particle.style.opacity = '0';
    }, 10);
  }
  document.body.appendChild(container);
  setTimeout(() => {
    document.body.removeChild(container);
  }, 700);
}

if (typeof window !== 'undefined') {
  window.addEventListener('pointerdown', e => {
    // не стрелять по скроллбарам
    if (e.button === 0 && e.x > 0 && e.y > 0 && e.x < window.innerWidth && e.y < window.innerHeight) {
      sparkleFirework(e.clientX, e.clientY);
    }
  });
}
