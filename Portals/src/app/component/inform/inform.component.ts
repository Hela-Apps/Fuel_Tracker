import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { City, Company, District } from 'src/app/service/common.interface';
import { CommonService } from 'src/app/service/common.service';
import { InformService } from 'src/app/service/inform.service';

@Component({
  selector: 'app-inform',
  templateUrl: './inform.component.html',
  styleUrls: ['./inform.component.css']
})
export class InformComponent implements OnInit {

  inform: FormGroup = new FormGroup({
    name: new FormControl("", Validators.required),
    companies: new FormControl(null, Validators.required),
    district: new FormControl(null, Validators.required),
    city: new FormControl(null, Validators.required),
  })
  companies: Company[] = [];
  companiesSource: Company[] = [];
  district: District[] = [];
  districtSource: District[] = [];
  city: City[] = [];
  citySource: City[] = [];
  isSelectedCity = false;

  defaultDistrict: { name: string; id: number } = {
    name: "Select District",
    id: 0,
  };
  defaultCity: { name: string; id: number } = {
    name: "Select City",
    id: 0,
  };

  constructor(private commonService: CommonService,private informService: InformService) { }

  ngOnInit(): void {
    this.getAllCompanies();
    this.getAllGetAllDistricts();
  }
  getAllCompanies(): void {

    this.commonService.getAllCompanies().subscribe({
      next: res => {
        this.companies = res;
       
      },
      error: error => {
        console.error(error)
      }
    })
  }
  handleCategoryFilter(value: any) {
    this.companies = this.companiesSource.filter(
      (s) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1
    );
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
  handleCityFilter(value: any) {
    this.city = this.citySource.filter(
      (s) => s.name.toLowerCase().indexOf(value.toLowerCase()) !== -1
    );
  }

  valueChangeDistrict(value: District): void {

    if (value.id === 0) {
      this.isSelectedCity = false;
    } else {
      this.isSelectedCity = true;

    }
    this.inform.controls["city"].reset();
    this.getAllCitiesByDistrictId(value.id)
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
  saveDetail(){
    this.informService.addStation(this.inform.value).subscribe({
      next: res => {
       
      },
      error: error => {
        console.error(error)
      }
    })
  }
}
