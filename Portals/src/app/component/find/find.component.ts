import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Category, City, District } from 'src/app/service/find.interface';
import { FindService } from 'src/app/service/find.service';

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
  isSubmitDisabled = true;






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
    categories: new FormControl(),
    district: new FormControl(),
    city: new FormControl(),
  })


  constructor(private findService: FindService) {
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

    this.findService.getAllCategories().subscribe({
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

    this.findService.getAllGetAllDistricts().subscribe({
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
      this.isSubmitDisabled = true;
    } else {
      this.isSelectedCity = true;
 
    }
    this.find.controls["city"].reset();
    this.getAllCitiesByDistrictId(value.id)
  }

  valueChangeCategories(value: Category): void {
    if (value.id === 0) {
      this.isSelectedProduct = false;
      this.isSubmitDisabled = true;
    } else {
      this.isSelectedProduct = true;
  
    }
    this.isSelectedCity = false
    this.find.controls["city"].reset();
    this.find.controls["district"].reset();
  }
  getAllCitiesByDistrictId(id: number): void {

    this.findService.getAllCitiesByDistrictId(id).subscribe({
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

  valueChangeCity(value: City): void {

    if (value.id === 0) {
      this.isSubmitDisabled = true;
    } else {
      this.isSubmitDisabled = false;
 
    }
   
  }
}
