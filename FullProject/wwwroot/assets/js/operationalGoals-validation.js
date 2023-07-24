
$(function () {
  var dataTablePermissions = $('.datatables-permissions'),
    dt_permission,
    userList = 'app-user-list.html';


  // Delete Record
  $('.datatables-permissions tbody').on('click', '.delete-record', function () {
    dt_permission.row($(this).parents('tr')).remove().draw();
  });

  // Filter form control to default size
  // ? setTimeout used for multilingual table initialization
  setTimeout(() => {
    $('.dataTables_filter .form-control').removeClass('form-control-sm');
    $('.dataTables_length .form-select').removeClass('form-select-sm');

    

    const FormValidation1 = FormValidation.formValidation(document.getElementById('addNewoperationalInfoForm'), {
      fields: { 
       
         operationalGoal_name: {
           validators: {
             notEmpty: {
               message: 'يرجى ادخال اسم الهدف التشفغيلي '
             },
             stringLength: {
               min: 1,
               max:30,
               message: ' يجب ان يكون عدد الأرقام من أقل من 30'
             },
 
             regexp: {
               regexp: /^[0-9 ]+$/,
               message: 'يجب ادخال ارقام  فقط'
             },
           }
         },
 
         operationalGoal_date: {
           validators: {
             notEmpty: {
               message: 'يرجى تعبئة هذا الحقل'
             },
 
           }
         }

       },
 
      
      plugins: {
        trigger: new FormValidation.plugins.Trigger(),
        bootstrap5: new FormValidation.plugins.Bootstrap5({
          // Use this for enabling/changing valid/invalid class
          eleValidClass: '',
          rowSelector: function (field, ele) {
            // field is the field name & ele is the field element
            return '.mb-3';
          }
        }),
        submitButton: new FormValidation.plugins.SubmitButton(),
        // Submit the form when all fields are valid
        // defaultSubmit: new FormValidation.plugins.DefaultSubmit(),
        autoFocus: new FormValidation.plugins.AutoFocus()
      }
    });
    


  }, 300);
});
'use strict';





// Add permission form validation
document.addEventListener('DOMContentLoaded', function (e) {
  (function () {
   
  })();
});




(function () {
    
  const selectAll = document.querySelector('#selectAll'),
  checkboxList = document.querySelectorAll('[type="checkbox"]'),
  filterInput = [].slice.call(document.querySelectorAll('.input-filter'));
selectAll.addEventListener('change', t => {
  checkboxList.forEach(e => {
    e.checked = t.target.checked;
  });
});
  filterInput.forEach(item => {
    item.addEventListener('click', () => {
      document.querySelectorAll('.input-filter:checked').length < document.querySelectorAll('.input-filter').length
        ? (selectAll.checked = false)
        : (selectAll.checked = true);
      calendar.refetchEvents();
    });
  });
}



)();