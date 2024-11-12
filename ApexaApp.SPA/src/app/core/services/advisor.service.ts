import { Component, inject, Injectable } from '@angular/core';
import { AdvisorClient } from '../Clients/advisor.client'
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})


export class AdvisorService {
  
  //baseUrl = 'https://localhost:5001/api/';
  //private http = inject(HttpClient);

  //private advisorClient = inject(AdvisorClient);

  constructor(private _AdvisorClient: AdvisorClient) {}

  getAdvisors() {
    return this._AdvisorClient.all();
  }

  deleteAdvisor(id: number) {
    return this._AdvisorClient.advisorDELETE(id);
  }
}
