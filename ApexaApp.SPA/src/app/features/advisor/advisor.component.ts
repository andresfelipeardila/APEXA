import { Component, inject, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { AdvisorDto } from '../../core/Clients/advisor.client';
import { AdvisorService } from '../../core/services/advisor.service';
import { NgStyle } from '@angular/common';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AddAdvisorComponent } from './modal/add-advisor/add-advisor.component';
import { UpdateAdvisorComponent } from './modal/update-advisor/update-advisor.component';

@Component({
  selector: 'app-advisor',
  standalone: true,
  imports: [MatButtonModule, MatTableModule, NgStyle],
  templateUrl: './advisor.component.html',
  styleUrl: './advisor.component.scss'
})
export class AdvisorComponent implements OnInit{
  private advisorService = inject(AdvisorService);
  private modalService = inject(NgbModal);

  title = 'Apexa App';
  advisors: AdvisorDto[] = [];

  displayedColumns: string[] = ['FULL NAME', 'SIN', 'ADDRESS', 'PHONE NUMBER', 'HEALTH STATUS', ''];
  columnsToDisplay: string[] = this.displayedColumns.slice();

  ngOnInit(): void {
    this.loadAdvisors();
  }

  loadAdvisors() {
    this.advisorService.getAdvisors().subscribe({
      next: response => this.advisors = response,
      error: error => console.log(error)
    });
  }

  deleteAdvisor(id: number) {
    this.advisorService.deleteAdvisor(id).subscribe({
      next: response => {
        this.loadAdvisors();
        console.log('Advisor Deleted');
      },
      error: error => console.log(error)
    });
  }

  openAddAdvisorModal() {
    const modalRef = this.modalService.open(AddAdvisorComponent);
		modalRef.componentInstance.name = 'World';
  }

  openUpdateAdvisorModal(advisor:AdvisorDto) {
    //console.log(advisor);
    
    const modalRef = this.modalService.open(UpdateAdvisorComponent);
		modalRef.componentInstance.advisor = advisor;
  }

}
