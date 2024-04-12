import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-payment-options',
  templateUrl: './payment-options.component.html',
  styleUrls: ['./payment-options.component.css'],
})
export class PaymentOptionsComponent implements OnInit {
  payments: any[] = [];
  selectedPayment: string | undefined;
  country: string | undefined;

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
      .get<any[]>('https://localhost:7231/Form/GetPayments/' + country)
      .subscribe((data) => {
        this.payments = data;
        this.country = country;
        console.log(data);
      });
  }
  navigateBack(): void {
    this.router.navigateByUrl('address/' + this.country);
  }
}
