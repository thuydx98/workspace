import { Routes } from '@angular/router';
import { MainComponent } from './components/main/main.component';
import { WsRoutes } from 'src/app/common/consts/route.const';

export const AppRoutes: Routes = [
  {
    path: WsRoutes.Home,
    component: MainComponent,
    children: [
      {
        path: WsRoutes.Home,
        loadChildren: () => import('./components/main/home/home.module').then(mod => mod.HomeModule)
      },
    ],
  },
  {
    path: '',
    loadChildren: () => import('./components/errors/error.module').then(mod => mod.ErrorModule)
  },
  {
    path: '**',
    redirectTo: WsRoutes.Home
  }
]

