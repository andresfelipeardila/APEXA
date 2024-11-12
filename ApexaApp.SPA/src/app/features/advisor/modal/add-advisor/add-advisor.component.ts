import { Component, EventEmitter, inject, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AdvisorService } from '../../../../core/services/advisor.service';
import { AdvisorDto } from '../../../../core/Clients/advisor.client';

@Component({
  selector: 'app-add-advisor',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule, MatIconModule, ReactiveFormsModule],
  templateUrl: './add-advisor.component.html',
  styleUrl: './add-advisor.component.scss'
})
export class AddAdvisorComponent implements OnInit{
  private advisorService = inject(AdvisorService);
  activeModal = inject(NgbActiveModal);
  advisorForm: FormGroup = this.fb.group({
    fullName: ['', Validators.required],
    sin: ['', [Validators.required, Validators.minLength(9)]],
    address: ['', []],
    phoneNumber: ['', [Validators.minLength(10)]]
  });

	@Output() advisorCreated= new EventEmitter<void>();

  // phoneFormControl = new FormControl('', [Validators.minLength(10)]);
  // fullnameFormControl = new FormControl('', [Validators.required]);
  // sinFormControl = new FormControl('', [Validators.required, Validators.minLength(9)]);

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    
  }

  clickAddAdvisor() {
    console.log(this.advisorForm.valid);

    if (this.advisorForm.valid) {
      console.log(this.advisorForm.value); // Get form values on submit
      this.advisorForm.value.id = 0;
      this.advisorService.addAdvisor(this.advisorForm.value).subscribe({
        next: response => {
          console.log('Advisor Added');
          this.advisorCreated.emit();
        },
        error: error => console.log(error)
      });
    } else {
      return;
    }


    this.activeModal.close('Close click')

  }
}
