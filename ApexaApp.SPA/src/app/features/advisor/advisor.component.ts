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

  //Open the Add Advisor Modal
  openAddAdvisorModal() {
    const addAdvisorModalRef = this.modalService.open(AddAdvisorComponent);
		
    // Listen for the form submission event from the modal
    addAdvisorModalRef.componentInstance.advisorCreated.subscribe(() => {
      this.loadAdvisors();
    });

  }

  openUpdateAdvisorModal(advisor:AdvisorDto) {
    const updateAdvisorModalRef = this.modalService.open(UpdateAdvisorComponent);

		updateAdvisorModalRef.componentInstance.advisor = advisor;

    // Listen for the form submission event from the modal
    updateAdvisorModalRef.componentInstance.advisorUpdated.subscribe(() => {
      this.loadAdvisors();
    });
  }

}
