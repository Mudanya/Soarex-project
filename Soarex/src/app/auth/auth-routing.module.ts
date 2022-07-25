import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './auth.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { LoginComponent } from './login/login.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { SignUpComponent } from './sign-up/sign-up.component';

const routes: Routes = [
  {path:'auth',redirectTo:'auth/login', pathMatch:'full'},
  {
    path:'auth', 
    component:AuthComponent,
    children:[
      {path:'login', component:LoginComponent},
      {path:'sign-up', component:SignUpComponent},
      {path:'forgot-password', component:ForgotPasswordComponent},
      {path:'reset-password', component:ResetPasswordComponent},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AuthRoutingModule { }
