import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { LayoutComponent } from "./core/components/layout/layout.component";

@Component({
  selector: 'app-root',
  imports: [ButtonModule, LayoutComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'katalogue-frontend';

}
