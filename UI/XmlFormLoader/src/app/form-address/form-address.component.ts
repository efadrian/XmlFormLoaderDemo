import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { __param } from 'tslib';
@Component({
  selector: 'app-form-address',
  templateUrl: './form-address.component.html',
  styleUrl: './form-address.component.css',
})
export class FormAddressComponent implements OnInit {
  @ViewChild('userForm') userForm: any;

  formData: any[] = [];
  selectedOptions: { [key: string]: string } = {};
  country: string | undefined;
  userAddress: any = {};

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private http: HttpClient
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      const country = params['country'] || 'UK';
      this.loadData(country);
    });
  }

  loadData(country: string) {
    this.http
      .get<any[]>('https://localhost:7231/Form/GetForm/' + country)
      .subscribe((data) => {
        this.formData = data;

        this.country = country;

        this.formData.forEach((field) => {
          if (field.type === 'select') {
            this.selectedOptions[field.fieldName] = field.defaultOption || '';
          }
        });
      });
  }

  navigateToPayments(): void {
    this.router.navigateByUrl('payment/' + this.country);
  }

  addUserAddress() {
    console.log(this.userAddress);
    /*
    this.http
      .post<any>(
        'https://localhost:7231/api/User/CreateUserAddress',
        this.userAddress
      )
      .subscribe(
        (response) => {
          console.log('User created successfully:', response);
          // Optionally, perform any other actions upon successful creation
        },
        (error) => {
          console.error('Error creating user:', error);
          // Optionally, handle error and provide user feedback
        }
      );
      */
  }

  onSubmit() {
    this.userForm.onSubmit();
    console.log(this.userForm);
  }
}
