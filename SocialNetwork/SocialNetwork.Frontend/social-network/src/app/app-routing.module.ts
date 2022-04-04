import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { PasswordResetComponent } from './password-reset/password-reset.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'login-component', component: LoginComponent },
  { path: 'register-component', component: RegisterComponent },
  { path: 'password-reset-component', component: PasswordResetComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
