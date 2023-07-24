/**
 *  Form Wizard  
 */

 'use strict';
 $(function () {
  const select2 = $('.select2'),
    selectPicker = $('.selectpicker');

  // Bootstrap select
  if (selectPicker.length) {
    selectPicker.selectpicker();
  }

  // select2
  if (select2.length) {
    select2.each(function () {
      var $this = $(this);
      $this.wrap('<div class="position-relative"></div>');
      $this.select2({
        placeholder: '',
        dropdownParent: $this.parent()
      });
    });
  }
});
 (function () {
 
   const flatPickrList = [].slice.call(document.querySelectorAll('.flatpickr-validation'));
   // Flat pickr
   if (flatPickrList) {
     flatPickrList.forEach(flatPickr => {
       flatPickr.flatpickr({
         allowInput: true,
         monthSelectorType: 'static'
       });
     });
   }
 
   // Wizard Validation
   // --------------------------------------------------------------------
   const wizardValidation = document.querySelector('#wizard-validation');
   if (typeof wizardValidation !== undefined && wizardValidation !== null) {
     // Wizard form
     const wizardValidationForm = wizardValidation.querySelector('#wizard-validation-form');
     // Wizard steps
     const wizardValidationFormStep1 = wizardValidationForm.querySelector('#LocatorDetailsValidation');
     const wizardValidationFormStep2 = wizardValidationForm.querySelector('#WarehouseQualificationValidation');
     // Wizard next prev button
     const wizardValidationNext = [].slice.call(wizardValidationForm.querySelectorAll('.btn-next'));
     const wizardValidationPrev = [].slice.call(wizardValidationForm.querySelectorAll('.btn-prev'));
 
     const validationStepper = new Stepper(wizardValidation, {
       linear: true
     });
 
     // add LocatorDetailsValidation 

     const FormValidation1 = FormValidation.formValidation(wizardValidationFormStep1, {
       fields: { 
        LocatorName: {
            validators: {
              notEmpty: {
                message: 'يرجى   إدخال اسم المحدد'
              },
              stringLength: {
                min: 1,
                max:50,
                message: '   يجب ان يكون حجم المدخلات أقل من 51 حرف  '
              }
  
              // ,
              // regexp: {
              //   regexp: /^[a-zA-Zأ-ي ]+$/,
              //   message: 'يجب ادخال احرف  فقط'
              // }
            }
          },
  
          light: {
              validators: {
                notEmpty: {
                  message: 'يرجى تعبئة هذا الحقل'
                },
                stringLength: {
                  min: 1,
                  max:6,
                  message: '  يجب ان يكون عدد الأرقام أقل من 7 '
                },
    
                regexp: {
                  regexp: /^[0-9 ]+$/,
                  message: 'يجب ادخال ارقام  فقط'
                }
              }
          },
  
          width: {
            validators: {
              notEmpty: {
                message: 'يرجى تعبئة هذا الحقل'
              },
              stringLength: {
                min: 1,
                max:6,
                message: ' يجب ان يكون عدد الأرقام من أقل من 7'
              },
  
              regexp: {
                regexp: /^[0-9 ]+$/,
                message: 'يجب ادخال ارقام  فقط'
              }
            }
          },
  
          height: {
            validators: {
              notEmpty: {
                message: 'يرجى تعبئة هذا الحقل'
              },
              stringLength: {
                min: 1,
                max:6,
                message: ' يجب ان يكون عدد الأرقام من أقل من 7'
              },
  
              regexp: {
                regexp: /^[0-9 ]+$/,
                message: 'يجب ادخال ارقام  فقط'
              }
            }
          },
  
  
  
          place: {
            validators: {
              notEmpty: {
                message: 'يرجى إدخال الموقع على الخريطة'
              }
            }
          },
  
          primaryWerehouseName: {
            validators: {
              notEmpty: {
                message: ' يرجى تعبئة هذا الحقل '
              }
            }
          },
  
          AWerehouseName: {
            validators: {
              notEmpty: {
                message: ' يرجى تعبئة هذا الحقل '
              }
            }
          },
  
          BWerehouseName:{
            validators: {
              notEmpty: {
                message: ' يرجى تعبئة هذا الحقل '
              }
            }
          },
  
          CWerehouseName: {
            validators: {
              notEmpty: {
                message: ' يرجى تعبئة هذا الحقل '
              }
            }
          }
       },
       plugins: {
         trigger: new FormValidation.plugins.Trigger(),
         bootstrap5: new FormValidation.plugins.Bootstrap5({
           // Use this for enabling/changing valid/invalid class
           // eleInvalidClass: '',
           eleValidClass: '',
           rowSelector: '.col-sm-12'
         }),
         autoFocus: new FormValidation.plugins.AutoFocus(),
         submitButton: new FormValidation.plugins.SubmitButton()
       },
       init: instance => {
         instance.on('plugins.message.placed', function (e) {
           //* Move the error message out of the `input-group` element
           if (e.element.parentElement.classList.contains('input-group')) {
             e.element.parentElement.insertAdjacentElement('afterend', e.messageElement);
           }
         });
       }
     }).on('core.form.valid', function () {
       // Jump to the next step when all fields in the current step are valid
       validationStepper.next();
     });
 
     // Personal info
     const FormValidation2 = FormValidation.formValidation(wizardValidationFormStep2, {
       fields: { 
         
     },
       plugins: {
         trigger: new FormValidation.plugins.Trigger(),
         bootstrap5: new FormValidation.plugins.Bootstrap5({
           // Use this for enabling/changing valid/invalid class
           // eleInvalidClass: '',
           eleValidClass: '',
           rowSelector: '.col-sm-12 , .col-md-5'
         }),
         autoFocus: new FormValidation.plugins.AutoFocus(),
         submitButton: new FormValidation.plugins.SubmitButton()
       }
     }).on('core.form.valid', function () {
         // You can submit the form
         // wizardValidationForm.submit()
         // or send the form data to server via an Ajax request
         // To make the demo simple, I just placed an alert
        // alert('Submitted..!!');
       });
 
    
 
     wizardValidationNext.forEach(item => {
       item.addEventListener('click', event => {
         // When click the Next button, we will validate the current step
         switch (validationStepper._currentIndex) {
           case 0:
             FormValidation1.validate();
             break;
 
           case 1:
             FormValidation2.validate();
             break;
 
           default:
             break;
         }
       });
     });
 
     wizardValidationPrev.forEach(item => {
       item.addEventListener('click', event => {
         switch (validationStepper._currentIndex) {
         
           case 1:
             validationStepper.previous();
             break;
 
           case 0:
 
           default:
             break;
         }
       });
     });
   }
 })();
 