import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CommonService } from 'src/app/service/common.service';
import { Category, City, District } from 'src/app/service/common.interface';


@Component({
  selector: 'app-find',
  templateUrl: './find.component.html',
  styleUrls: ['./find.component.css']
})
export class FindComponent implements OnInit {

  categories: Category[] = [];
  categorySource: Category[] = [];
  district: District[] = [];
  districtSource: District[] = [];
  city: City[] = [];
  citySource: City[] = [];
  isSelectedCity = false;
  isSelectedProduct = false;


  defaultCategories: { name: string; id: number } = {
    name: "Select  Petrol,Diesel,Gas etc here...",
    id: 0,
  };
  defaultDistrict: { name: string; id: number } = {
    name: "Select District",
    id: 0,
  };
  defaultCity: { name: string; id: number } = {
    name: "Select City",
    id: 0,
  };
  find: FormGroup = new FormGroup({
    categories: new FormControl(null, Validators.required),
    district: new FormControl(null, Validators.required),
    city: new FormControl(null, Validators.required),
  })


  constructor(private commonService: CommonService) {
    this.categories = this.categorySource.slice();
    this.district = this.districtSource.slice();
  }

  ngOnInit(): void {

    this.getAllCategories();
    this.getAllGetAllDistricts();
  }
  handleCategoryFilter(value: any) {
    this.categories = this.categorySource.filter(
      (s) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1
    );
  }

  getAllCategories(): void {

    this.commonService.getAllCategories().subscribe({
      next: res => {
        this.categories = res;
        this.categorySource = res
      },
      error: error => {
        console.error(error)
      }
    })
  }

  getAllGetAllDistricts(): void {

    this.commonService.getAllGetAllDistricts().subscribe({
      next: res => {
        this.district = res;
        this.districtSource = res;

      },
      error: error => {
        console.error(error)
      }
    })
  }
  handleDistrictFilter(value: any) {
    this.district = this.districtSource.filter(
      (s) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1
    );
  }

  valueChangeDistrict(value: District): void {

    if (value.id === 0) {
      this.isSelectedCity = false;
    } else {
      this.isSelectedCity = true;

    }
    this.find.controls["city"].reset();
    this.getAllCitiesByDistrictId(value.id)
  }

  valueChangeCategories(value: Category): void {
    if (value.id === 0) {
      this.isSelectedProduct = false;
    } else {
      this.isSelectedProduct = true;

    }
    this.isSelectedCity = false
    this.find.controls["city"].reset();
    this.find.controls["district"].reset();
  }
  getAllCitiesByDistrictId(id: number): void {

    this.commonService.getAllCitiesByDistrictId(id).subscribe({
      next: res => {
        this.city = res;
        this.citySource = res;

      },
      error: error => {
        console.error(error)
      }
    })
  }
  handleCityFilter(value: any) {
    this.city = this.citySource.filter(
      (s) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1
    );
  }

  valueChangeCity(value: Category): void {
    if (value.id === 0) {
      this.find.controls["city"].reset();
    }
  }

}
