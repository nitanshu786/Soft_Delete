
import { EmployesService } from './../employes.service';
import { Employe } from './../employe';
import Swal from 'sweetalert2';
import { Component } from '@angular/core';



@Component({
  selector: 'app-employe',
  templateUrl: './employe.component.html',
  styleUrls: ['./employe.component.scss']
})
export class EmployeComponent {
  Emplist: Employe[]=[];
  NewEmploye:Employe= new Employe();
  EditEmploye:Employe= new Employe();
  url:any;
 
  constructor(private Empservice : EmployesService){}

  ngOnInit(): void {
   
    
    this.getALL();
  }
  

  onselected(event: any): void {
  const file: File = event.target.files[0];
  const reader = new FileReader();
  reader.readAsDataURL(file);
  reader.onload = (event:any) => {
    this.url=event.target.result;
    const base64String: string = reader.result as string;
    this.NewEmploye.picture= base64String
    this.EditEmploye.picture=base64String
    
    
  };
}


  getALL()
  {
    

    this.Empservice.GetEmployes().subscribe(
      (respnse)=>{
        this.Emplist=respnse
        console.log(this.Emplist)
      },
      (error)=>{
        console.log(error);
      }
    )
  }
  
  Save()
  {
    
    this.Empservice.saveEmployes(this.NewEmploye). subscribe(
      (response)=>{
        this .getALL();
        this.NewEmploye.name="";
        this.NewEmploye.address="";
        this.NewEmploye.email="";
        this.NewEmploye.picture="";
      },
      (error)=>{
        console.log(error)
      }
    )
    
  }

  EditClick(employe:Employe){
    this.EditEmploye=employe
    
  }

  Update()
  {
    this.Empservice.updateemploye(this.EditEmploye).subscribe(
      (response)=>{
        this.getALL();
      },
      
      (error)=>{
        console.log(error);
      }
    )
  }


DeleteClick(id:Number)
{  

  Swal.fire({  
    title: 'Are you sure want to remove?',  
    text: 'You will not be able to recover this file!',  
    icon: 'warning',  
    showCancelButton: true,  
    confirmButtonText: 'Yes, delete it!',  
    cancelButtonText: 'No, keep it'  
  }).then((result) => {  
    if (result.value)
    {
      this.Empservice.Delete(id).subscribe(
        (response)=>{
          this.getALL();
        })

      Swal.fire(  
        'Deleted!',  
        'Your imaginary file has been deleted.',  
        'success'  
      )  
    } else if (result.dismiss === Swal.DismissReason.cancel) {  
      Swal.fire(  
        'Cancelled',  
        'Your imaginary file is safe :)',  
        'error'  
      )  
    }  
  })  
}  
}

