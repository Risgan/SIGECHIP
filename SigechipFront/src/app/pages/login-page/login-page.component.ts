import { Component } from '@angular/core';
import { PrimengModule } from '../../shared/primeng/primeng.module';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [PrimengModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent {

}
