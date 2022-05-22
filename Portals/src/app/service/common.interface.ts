export interface Category {
    id: number
    name: string
  }

  export interface District {
    id: number
    name: string
  }
  export interface City {
    id: number
    name: string
  }
  
  export interface Company {
    id: number
    name: string
  }
  export interface Station {
    id?: number
  name  : string,
  isActive?: boolean,
  companyId: number,
  cityId: number
  }

  export interface FuelDetail {
  districtId: number
  cityId  : string,
  categoryId: boolean,
  categoryName: string,
  stationName: string,
  availabilityStatus: boolean,
  lastUpdatedTime: Date
  }


