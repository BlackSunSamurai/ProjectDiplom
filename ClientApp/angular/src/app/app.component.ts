import {Component, OnInit} from '@angular/core';
import { AccountService } from './account/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'Shop';
  token: string;

  constructor(private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.token = localStorage.getItem('token');
    this.loadCurrentUser();
  }

  loadCurrentUser() {
    if (this.token) {
      this.accountService.loadCurrentUser(this.token).subscribe(
        () => {
          console.log('User Loaded');
        },
        (error) => {
          console.log(error);
        }
      );
    }
    else
    {
      this.accountService.setCurrentUserToNull();
    }
  }

}
