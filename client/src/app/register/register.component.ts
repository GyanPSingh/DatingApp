import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit, OnChanges, Input, Output, EventEmitter } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit, OnDestroy {
  // @Input() usersFromHomeComponent: any;
  @Output() cancelRegister = new EventEmitter();
  model: any = {}

  constructor(private accountService: AccountService, private toastr:ToastrService) { }

  RegisterComponent() {

  }

  ngOnInit(): void {
    //console.log("ngOnInit");
  }

  register() {
    //console.log(this.model);
    this.accountService.register(this.model).subscribe({
      next: response => {
        //console.log(response);
        this.cancel();
      },
      error: error => {this.toastr.error(error.error);
        console.log(error)
      }
    })

  }
  cancel() {    
    this.cancelRegister.emit(false);
  }

  ngOnDestroy(): void {
    //console.log("ngOnDestroy");
  }

}
