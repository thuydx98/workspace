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
        // loadChildren: () => import('./components/main/home/home.module').then(mod => mod.HomeModule)
        loadChildren: () => import('./components/main/asset/asset.module').then(mod => mod.AssetModule)
      },
      {
        path: WsRoutes.Assets,
        loadChildren: () => import('./components/main/asset/asset.module').then(mod => mod.AssetModule)
      },
      {
        path: WsRoutes.Wiki,
        loadChildren: () => import('./components/main/wiki/wiki.module').then(mod => mod.WikiModule)
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

