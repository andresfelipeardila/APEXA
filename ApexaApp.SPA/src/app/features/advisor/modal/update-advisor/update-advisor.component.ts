import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AdvisorService } from '../../../../core/services/advisor.service';
import { AdvisorDto } from '../../../../core/Clients/advisor.client';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-update-advisor',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatIconModule, ReactiveFormsModule],
  templateUrl: './update-advisor.component.html',
  styleUrl: './update-advisor.component.scss'
})
export class UpdateAdvisorComponent {
  
  private advisorService = inject(AdvisorService);
  activeModal = inject(NgbActiveModal);
  advisorForm: FormGroup = this.fb.group({
    id: [0,[]],
    fullName: ['', Validators.required],
    sin: ['', [Validators.required, Validators.minLength(9)]],
    address: ['', []],
    phoneNumber: ['', [Validators.minLength(10)]],
    healthStatus: ['',[]]
  });

  @Input() advisor: AdvisorDto = new(AdvisorDto);
  @Output() advisorUpdated= new EventEmitter<void>();
	
  // phoneFormControl = new FormControl('', [Validators.minLength(10)]);
  // fullnameFormControl = new FormControl('', [Validators.required]);
  // sinFormControl = new FormControl('', [Validators.required, Validators.minLength(9)]);


  constructor(private fb: FormBuilder, private toastr: ToastrService) {}

  ngOnInit(): void {
    console.log(this.advisor);
    
    this.populateFields();
  }

  populateFields() {
    this.advisorForm.get('fullName')?.patchValue(this.advisor.fullName);
    this.advisorForm.get('sin')?.patchValue(this.advisor.sin);
    this.advisorForm.get('address')?.patchValue(this.advisor.address);
    this.advisorForm.get('phoneNumber')?.patchValue(this.advisor.phoneNumber);
    this.advisorForm.get('healthStatus')?.patchValue(this.advisor.healthStatus);
  }

  clickUpdateAdvisor() {
    if (this.advisorForm.valid) {
      this.advisorForm.value.id = this.advisor.id;
      this.advisorService.updateAdvisor(this.advisorForm.value).subscribe({
        next: response => {
          console.log('Advisor Updated');
          this.toastr.success('Advisor Updated', 'Advisor Updated');
          this.advisorUpdated.emit();
        },
        error: error => {
          console.log(error);
          this.toastr.error('Error while updating the advisor', '');
        } 
      });
    } else {
      return;
    }


    this.activeModal.close('Close click')

  }
}
