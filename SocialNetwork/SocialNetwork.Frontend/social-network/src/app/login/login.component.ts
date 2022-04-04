import { Component, OnInit } from '@angular/core';
import { Credentials } from '../app';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() { }

  model = new Credentials('login', 'password')

  onSubmit() {
    console.log("zalogowano");
  }
  
  ngOnInit(): void {
  }

}
