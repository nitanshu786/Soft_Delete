import { EmployesService } from './../employes.service';
import { Employe } from './../employe';
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
 
  constructor(private Empservice : EmployesService){}

  ngOnInit(): void {
    this.getALL();
  }



  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    const formData: FormData = new FormData();
    formData.append('image', file, file.name);
     this.Empservice.  uploadImage(formData);
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

  update()
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

  deleteclick(id:number)
  {
    
    this.Empservice.Delete(id).subscribe(
      (response)=>{
        this.getALL();
      },
      (error)=>{
        console.log(error);
      }
    )
  }

}
