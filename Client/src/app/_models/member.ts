import { Photo } from "./photo"


export interface Member {
    id: number
    username: string
    photoUrl: string
    age: number
    knownAs: string
    created: string
    lastActive: string
    gender: string
    lookingFor: string
    interests: string
    myProperty: number
    city: string
    country: string
    photos: Photo[]
  }
  
