import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'feed',
    loadComponent: () => import('./features/feed/pages/feed-main/feed-main.component').then(m => m.FeedMainComponent)
  },
  {
    path: 'discovery',
    loadComponent: () => import('./features/discover/pages/discover-main/discover-main.component').then(m => m.DiscoverMainComponent)
  },
  {
    path: 'forum',
    loadComponent: () => import('./features/forum/pages/forum-main/forum-main.component').then(m => m.ForumMainComponent)
  },
  {
    path: 'catalogue',
    loadComponent: () => import('./features/catalogue/pages/catalogue-main/catalogue-main.component').then(m => m.CatalogueMainComponent)
  },
  {
    path: 'chat',
    loadComponent: () => import('./features/chat/pages/chat-main/chat-main.component').then(m => m.ChatMainComponent)
  },
  {
    path: 'user',
    children: [
      {
        path: 'profile',
        loadComponent: () => import('./features/user/pages/profile/profile.component').then(m => m.ProfileComponent)
      },
      {
        path: 'settings',
        loadComponent: () => import('./features/user/pages/settings/settings.component').then(m => m.SettingsComponent)
      }
    ]
  },
  { path: '', redirectTo: '/feed', pathMatch: 'full' }, // Default route
  { path: '**', loadComponent: () => import('./shared/pages/not-found/not-found.component').then(m => m.NotFoundComponent) } // 404 page
];
