import { Component } from '@angular/core';
import { LayoutComponent } from "../layout/layout.component";
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-layout-wrapper',
  imports: [LayoutComponent, RouterOutlet],
  templateUrl: './layout-wrapper.component.html',
  styleUrl: './layout-wrapper.component.scss'
})
export class LayoutWrapperComponent {

}
