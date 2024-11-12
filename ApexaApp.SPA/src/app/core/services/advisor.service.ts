import { Component, inject, Injectable, signal } from '@angular/core';
import { AdvisorClient, AdvisorDto } from '../Clients/advisor.client'
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})


export class AdvisorService {

  private advisorsList = signal<AdvisorDto[]>([]);

  constructor(private _AdvisorClient: AdvisorClient) {}

  getAdvisors() {

    return this._AdvisorClient.all();
  }

  deleteAdvisor(id: number) {
    return this._AdvisorClient.advisorDELETE(id);
  }

  addAdvisor(advisor: AdvisorDto) {
    return this._AdvisorClient.advisorPOST(advisor);
  }

  updateAdvisor(advisor: AdvisorDto) {
    return this._AdvisorClient.update(advisor);
  }
}
