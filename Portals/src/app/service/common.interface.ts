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


