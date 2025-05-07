import { Component, output } from '@angular/core';
import { Bell, LucideAngularModule, Plus, Search, User } from 'lucide-angular';

@Component({
  selector: 'app-header',
  imports: [LucideAngularModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss',
})
export class HeaderComponent {

  Plus = Plus;
  Search = Search;
  Bell = Bell;
  User = User;

}
