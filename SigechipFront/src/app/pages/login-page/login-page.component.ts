import { Component, OnInit } from '@angular/core';
import { PrimengModule } from '../../shared/primeng/primeng.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-login-page',
  standalone: true,
  imports: [PrimengModule, FormsModule],
  templateUrl: './login-page.component.html',
  styleUrl: './login-page.component.scss'
})
export class LoginPageComponent implements OnInit {
  
  _showPassword: string = 'password';
  _loadingButton: boolean = false;

  ngOnInit(): void {
  }


  load() {
      this._loadingButton = true;

      setTimeout(() => {
          this._loadingButton = false
      }, 2000);
  }


  togglePassword() {
    this._showPassword = this._showPassword === 'text' ? 'password' : 'text';
  }

}
