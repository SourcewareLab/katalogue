import { Component, input, signal } from '@angular/core';
import { SidebarItem } from './sidebar.model';
import { RouterLink } from '@angular/router';
import {Book, ChevronLeft, ChevronRight, Home, LucideAngularModule, Mail, MessageSquare, Search, Settings, User} from 'lucide-angular'
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-sidebar',
  imports: [RouterLink, LucideAngularModule, CommonModule],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss'
})
export class SidebarComponent {
  isExpanded = signal(false);

  SidebarWidthCollapsed = "60px"
  SidebarWidthExpanded = "240px"

  ChevronRight = ChevronRight;
  ChevronLeft = ChevronLeft;


  toggleSidebar() {
    this.isExpanded.update(b => !b);
  }

  // Main navigation items
  navItems: SidebarItem[] = [
    { icon: Home, title: 'Feed', link: '/feed', iconProps: { size: 20 } },
    { icon: Search, title: 'Discovery', link: '/discovery', iconProps: { size: 20 } },
    { icon: MessageSquare, title: 'Forum', link: '/forum', iconProps: { size: 20 } },
    { icon: Book, title: 'My Catalogue', link: '/catalogue', iconProps: { size: 20 } },
    { icon: Mail, title: 'Chat', link: '/chat', iconProps: { size: 20 } }
  ];

  // Bottom items
  bottomItems: SidebarItem[] = [
    { icon: Settings, title: 'Settings', link: '/settings', iconProps: { size: 20 } },
    { icon: User, title: 'My Profile', link: '/profile', iconProps: { size: 20 } }
  ];
}
